using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Component
{
    public class CategorySummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategorySummaryViewComponent(IServiceManager manager)
        {
            _serviceManager = manager;
        }

        public string Invoke()
        {
            return _serviceManager
                .CategoryService
                .GetAllCategoies(false)
                .Count()
                .ToString();
        }
    }
}
