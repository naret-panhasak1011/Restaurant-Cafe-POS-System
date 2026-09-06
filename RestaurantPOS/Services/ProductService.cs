using System;
using System.Collections.Generic;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository = new ProductRepository();

        public List<Product> Search(string term = null) => _productRepository.Search(term);

        public List<Product> GetAllAvailable() => _productRepository.GetAllAvailable();

        public List<Product> GetByCategory(int categoryId) => _productRepository.GetByCategory(categoryId);

        public void AddProduct(Product product)
        {
            Validate(product);
            if (_productRepository.NameExists(product.ProductName.Trim()))
                throw new InvalidOperationException("A product with this name already exists.");

            _productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            Validate(product);
            if (_productRepository.NameExists(product.ProductName.Trim(), product.ProductID))
                throw new InvalidOperationException("Another product already uses this name.");

            _productRepository.Update(product);
        }

        public void DeleteProduct(int productId) => _productRepository.Delete(productId);

        public void UpdateStock(int productId, int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative.");
            _productRepository.UpdateStock(productId, newQuantity);
        }

        private static void Validate(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new ArgumentException("Product name is required.");
            if (product.UnitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative.");
            if (product.StockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative.");
            if (product.CategoryID <= 0)
                throw new ArgumentException("Please select a category.");
        }
    }
}
