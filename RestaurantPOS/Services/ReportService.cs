using System;
using System.Collections.Generic;
using System.Data;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    public class ReportService
    {
        private readonly ReportRepository _reportRepository = new ReportRepository();

        public List<SalesSummaryRow> GetSales(DateTime? fromDate, DateTime? toDate, string paymentMethod = null, string orderStatus = null)
            => _reportRepository.GetSales(fromDate, toDate, paymentMethod, orderStatus);

        public (int OrderCount, decimal Revenue, decimal Tax, int ItemsSold) GetTodaySummary()
            => _reportRepository.GetTodaySummary();

        public DataTable GetBestSellers(DateTime? fromDate, DateTime? toDate, int top = 10)
            => _reportRepository.GetBestSellers(fromDate, toDate, top);
    }
}
