using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Component
{
    public class ProductFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
