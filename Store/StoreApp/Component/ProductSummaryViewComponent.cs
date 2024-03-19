using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;
using System.ComponentModel;

namespace StoreApp.Component
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly Cart _services;

        public ProductSummaryViewComponent(Cart services)
        {
            _services = services;
        }

        public string Invoke()
        {
            return _services.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}
