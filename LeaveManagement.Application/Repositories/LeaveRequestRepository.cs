using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Data;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;
using Microsoft.AspNetCore.Http;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, UserManager<Employee> userManager,
            ILeaveAllocationRepository leaveAllocationRepository, AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Canceled = true;
            leaveRequest.Approved = false;
            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request Canceled", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been Canceled Successfully.");
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved)
            {
                var allocation = await _leaveAllocationRepository
                    .GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                var daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = approved ? "Approved" : "Declined";

            await _emailSender.SendEmailAsync(user.Email, $"Leave Request {approvalStatus}", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus}.");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var leaceAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if (leaceAllocation is null)
                return false;

            var daysRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            if (daysRequested > leaceAllocation.NumberOfDays)
                return false;

            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, "Leave Request Submitted Successfuly", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval.");

            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveReuests = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveReuests.Count,
                ApprovedRequests = leaveReuests.Count(x => x.Approved == true),
                PendingRequests = leaveReuests.Count(x => x.Approved == null),
                RejectedRequests = leaveReuests.Count(x => x.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveReuests)
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(x => x.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (leaveRequest is null)
                return null;

            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);

            var model = new EmployeeLeaveRequestViewVM(allocations, requests);

            return model;
        }
    }
}
