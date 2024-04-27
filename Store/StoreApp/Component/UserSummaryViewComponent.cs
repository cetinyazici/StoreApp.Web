using Services.Contracts;

namespace StoreApp.Component
{
    public class UserSummaryViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public UserSummaryViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public string Invoke()
        {
            return _serviceManager
                .AuthService
                .GetAllUsers()
                .Count()
                .ToString();
        }
    }
}
