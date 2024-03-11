using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProducttController : Controller
    {
        private readonly IServiceManager _services;

        public ProducttController(IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var model = _services.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Categoires = GetCategoriesSelectList();

            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            return ViewBag.Categoires = new SelectList(
                _services.CategoryService.GetAllCategoies(false),
                "CategoryId", //veri alanı
                "CategoryName", //Text alanı
                "1" //default alanı
                );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _services.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categoires = GetCategoriesSelectList();
            var model = _services.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] ProductDtoForUpdate product)
        {
            if (ModelState.IsValid)
            {
                _services.ProductService.UpdateOneProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _services.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}
