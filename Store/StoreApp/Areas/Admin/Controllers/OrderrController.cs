using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderrController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderrController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var order = _manager.OrderService.Orders;
            return View(order);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }
    }
}
