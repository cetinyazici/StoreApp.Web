using Entities.Models;

namespace StoreApp.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public Pagination Pagination { get; set; } = new Pagination();
        public int TotalCount => Products.Count();
    }
}
