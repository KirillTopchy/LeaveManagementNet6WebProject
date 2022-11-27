﻿using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, UserManager<Employee> userManager,
            ILeaveAllocationRepository leaveAllocationRepository)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);
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

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(x => x.RequestingEmployeeId == employeeId).ToListAsync();
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = _mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));

            var model = new EmployeeLeaveRequestViewVM(allocations, requests);

            return model;
        }
    }
}