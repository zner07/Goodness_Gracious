using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVault_Inventory_Management_System
{
    public class InventoryManager : User
    {
        private string _employeeId;

        public string EmployeeId { get { return _employeeId; } set { _employeeId = value; } }

        public InventoryManager(string name, string username, string password, string employeeId)
            : base(name, username, password)
        {
            _employeeId = employeeId;
        }

        public override bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }

        public void AddProduct(List<Product> products, Product p)
        {
            products.Add(p);
        }

        public void EditProduct(Product p, string newBrand, decimal newPrice)
        {
            p.Brand = newBrand;
            p.Price = newPrice;
        }

        public void RestockProduct(Product p, int quantity)
        {
            p.StockQuantity += quantity;
        }

        public void SellProduct(Product p)
        {
            if (p.StockQuantity > 0)
                p.StockQuantity--;
        }
    }
}
