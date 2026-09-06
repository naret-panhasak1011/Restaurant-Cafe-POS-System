using System;
using System.Collections.Generic;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();

        public List<Category> GetAll(string search = null) => _categoryRepository.GetAll(search);

        public void AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name is required.");
            if (_categoryRepository.NameExists(name.Trim()))
                throw new InvalidOperationException("A category with this name already exists.");

            _categoryRepository.Insert(new Category { CategoryName = name.Trim() });
        }

        public void UpdateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new ArgumentException("Category name is required.");
            if (_categoryRepository.NameExists(category.CategoryName.Trim(), category.CategoryID))
                throw new InvalidOperationException("A category with this name already exists.");

            _categoryRepository.Update(category);
        }

        public void DeleteCategory(int categoryId) => _categoryRepository.Delete(categoryId);
    }
}
