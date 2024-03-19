using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Component
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly Cart _manager;

        public CategoriesMenuViewComponent(Cart manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var category = _manager.CategoryService.GetAllCategoies(false);

            return View(category);
        }
    }
}
