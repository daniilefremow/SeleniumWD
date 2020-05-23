using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWD.business_object
{
    class Products
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitsInStock { get; set; }
        public string UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; }

        public Products(string ProductName, string Category, string Supplier, string UnitPrice, string QuantityPerUnit, string UnitsInStock, string UnitsOnOrder, string ReorderLevel)
        {
            this.ProductName = ProductName;
            this.Category = Category;
            this.Supplier = Supplier;
            this.UnitPrice = UnitPrice;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReorderLevel = ReorderLevel;
        }
        public Products(string ProductId, string ProductName, string Category, string Supplier, string UnitPrice, string QuantityPerUnit, string UnitsInStock, string UnitsOnOrder, string ReorderLevel)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Category = Category;
            this.Supplier = Supplier;
            this.UnitPrice = UnitPrice;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReorderLevel = ReorderLevel;
        }

    }
}
