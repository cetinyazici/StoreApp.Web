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
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCategory(CategoryDtoForInsertion categoryDto)
        {
            Category category = new Category()
            {
                CategoryId = categoryDto.CategoryId,
                CategoryName = categoryDto.CategoryName,
            };
            _manager.Category.Create(category);
            _manager.Save();
        }

        public IEnumerable<Category> GetAllCategoies(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

    }
}
