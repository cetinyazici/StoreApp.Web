using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Component
{
    public class OrderInProgressViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public OrderInProgressViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public string Invoke()
        {
            return _serviceManager
                .OrderService
                .NumberOfInProcces
                .ToString();
        }
    }
}
