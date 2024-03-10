using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IMapper mapper, IRepositoryManager manager)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            //    new Product
            //{
            //    ProductName=productDto.ProductName,
            //    ProductId=productDto.ProductId,
            //    Price=productDto.Price,
            //    CategoryId=productDto.CategoryId,
            //};
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false);
            if (product is not null)
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }

        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);

        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            if (product == null)
            {
                throw new Exception("Product not found!!");
            }
            return product;
        }

        public void UpdateOneProduct(Product product)
        {
            var model = _manager.Product.GetOneProduct(product.ProductId, true);
            model.ProductName = product.ProductName;
            model.Price = product.Price;
            _manager.Save();
        }
    }
}
