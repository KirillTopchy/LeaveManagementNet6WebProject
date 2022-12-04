using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LeaveManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var exceptionHandlerPartFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPartFeature is not null)
            {
                Exception exception = exceptionHandlerPartFeature.Error;
                _logger.LogError(exception, $"Error Encountered By Iser: {this.User?.Identity?.Name} | request Id: {requestId}");
            }

            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}