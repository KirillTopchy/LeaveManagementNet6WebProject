using LeaveManagement.Common.Constants;
using LeaveManagement.Data;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILogger<LeaveRequestsController> _logger;

        public LeaveRequestsController(ApplicationDbContext context, ILeaveRequestRepository leaveRequestRepository,
            ILogger<LeaveRequestsController> logger)
        {
            _context = context;
            _leaveRequestRepository = leaveRequestRepository;
            _logger = logger;
        }

        public async Task<ActionResult> MyLeave()
        {
            var model = await _leaveRequestRepository.GetMyLeaveDetails();
            return View(model);
        }

        [Authorize(Roles = Roles.Administrator)]
        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestRepository.GetAdminLeaveRequestList();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await _leaveRequestRepository.GetLeaveRequestAsync(id);
            if (model is null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await _leaveRequestRepository.ChangeApprovalStatus(id, approved);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Approving Leave Request");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await _leaveRequestRepository.CancelLeaveRequest(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Canceling Leave Request");
                throw;
            }

            return RedirectToAction(nameof(MyLeave));
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var model = new LeaveRequestCreateVM
            {
                LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name"),
            };

            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isValidRequest = await _leaveRequestRepository.CreateLeaveRequest(model);
                    if (isValidRequest)
                    {
                        return RedirectToAction(nameof(MyLeave));
                    }
                    ModelState.AddModelError(string.Empty, "You have exceeded your allocation with this request.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Creating Leave Request");
                ModelState.AddModelError(string.Empty, "An Error Has Occued. Please Try Again Later.");
            }

            model.LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name", model.LeaveTypeId);
            return View(model);
        }
    }
}
