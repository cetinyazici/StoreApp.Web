using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProducttController : Controller
    {
        private readonly Services.Contracts.IServiceManager _services;

        public ProducttController(Services.Contracts.IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            var products = _services.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrenPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _services.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination

            });
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
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operations
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = String.Concat("/images/", file.FileName);
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
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operations
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = String.Concat("/images/", file.FileName);
                _services.ProductService.UpdateOneProduct(productDto);
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
