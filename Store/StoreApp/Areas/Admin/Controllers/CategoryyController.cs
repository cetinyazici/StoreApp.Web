using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryyController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CategoryyController(IServiceManager manager)
        {
            _serviceManager = manager;
        }

        public IActionResult Index()
        {
            var categories = _serviceManager.CategoryService.GetAllCategoies(false);
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CategoryDtoForInsertion categoryDto)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.CategoryService.CreateCategory(categoryDto);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
