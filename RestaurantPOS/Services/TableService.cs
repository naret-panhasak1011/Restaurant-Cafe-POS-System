using System.Collections.Generic;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    public class TableService
    {
        private readonly TableRepository _tableRepository = new TableRepository();

        public List<RestaurantTable> GetTableOverview() => _tableRepository.GetAllWithActiveOrders();

        public List<RestaurantTable> GetAll(string search = null) => _tableRepository.GetAll(search);

        public void AddTable(string name, int capacity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new System.ArgumentException("Table name is required.");
            if (capacity <= 0)
                throw new System.ArgumentException("Capacity must be greater than zero.");

            _tableRepository.Insert(new RestaurantTable { TableName = name.Trim(), Capacity = capacity, Status = "Available" });
        }

        public void UpdateTable(RestaurantTable table)
        {
            if (string.IsNullOrWhiteSpace(table.TableName))
                throw new System.ArgumentException("Table name is required.");
            if (table.Capacity <= 0)
                throw new System.ArgumentException("Capacity must be greater than zero.");

            _tableRepository.Update(table);
        }

        public void DeleteTable(int tableId) => _tableRepository.Delete(tableId);

        public void SetReserved(int tableId) => _tableRepository.UpdateStatus(tableId, "Reserved");

        public void SetAvailable(int tableId) => _tableRepository.UpdateStatus(tableId, "Available");
    }
}
