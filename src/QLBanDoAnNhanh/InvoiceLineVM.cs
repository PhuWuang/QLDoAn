using System;
using Microsoft.Reporting.WinForms; // Cho ReportViewer
using System.IO;                    // Cho Path.Combine
using System.Collections.Generic;   // Cho List<>

namespace QLBanDoAnNhanh // Hoặc namespace của bạn
{
    public class InvoiceLineVM
    {
        public string Item { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        public InvoiceLineVM() { }

        public InvoiceLineVM(string item, int qty, decimal price)
        {
            Item = item;
            Qty = qty;
            Price = price;
            Amount = qty * price;
        }
    }
    public class InvoiceHeaderVM
    {
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Employee { get; set; }
        public DateTime PrintedAt { get; set; }
        public decimal VATRate { get; set; }  // Ví dụ: 0.05m cho 5%
    }

}