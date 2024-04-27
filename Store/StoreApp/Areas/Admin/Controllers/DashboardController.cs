using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public DashboardController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            TempData["info"] = $"Welcome back, {DateTime.Now.ToShortTimeString()}";
            return View();
        }

    }
}
