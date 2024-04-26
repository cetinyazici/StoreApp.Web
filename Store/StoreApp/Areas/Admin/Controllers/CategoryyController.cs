using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryyController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryyController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
