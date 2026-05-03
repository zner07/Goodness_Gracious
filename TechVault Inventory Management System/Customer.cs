using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVault_Inventory_Management_System
{
    public class Customer : User
    {
        private string _customerId;

        public string CustomerId { get { return _customerId; } set { _customerId = value; } }

        public Customer(string name, string username, string password, string customerId)
            : base(name, username, password)
        {
            _customerId = customerId;
        }

        public override bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }

        public List<Product> SearchProduct(List<Product> products, string query)
        {
            return products.FindAll(p =>
                p.Brand.ToLower().Contains(query.ToLower()) ||
                p.ModelName.ToLower().Contains(query.ToLower()));
        }

        public List<Product> FilterByCategory(List<Product> products, string category)
        {
            return products.FindAll(p => p.Category == category);
        }
    }
}
