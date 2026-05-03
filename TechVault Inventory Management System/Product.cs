using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVault_Inventory_Management_System
{
    public abstract class Product
    {
        private string _modelName;
        private string _brand;
        private decimal _price;
        private int _stockQuantity;
        private string _category;

        public string ModelName { get { return _modelName; } set { _modelName = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Category { get { return _category; } set { _category = value; } }

        public decimal Price
        {
            get { return _price; }
            set { if (value > 0) _price = value; } // Encapsulation: validation
        }

        public int StockQuantity
        {
            get { return _stockQuantity; }
            set { if (value >= 0) _stockQuantity = value; } // No negative stock
        }

        public Product(string modelName, string brand, decimal price, int stock, string category)
        {
            _modelName = modelName;
            _brand = brand;
            _price = price;
            _stockQuantity = stock;
            _category = category;
        }

        // Polymorphism: each subclass overrides this
        public abstract string GetSpecs();
    }
}
