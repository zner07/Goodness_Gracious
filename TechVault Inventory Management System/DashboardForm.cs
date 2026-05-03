using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TechVault_Inventory_Management_System
{
    public partial class DashboardForm : Form
    {
        private List<Product> products = new List<Product>();
        private InventoryManager manager = new InventoryManager(
            "Admin", "admin", "admin123", "EMP001");

        public DashboardForm()
        {
            InitializeComponent();
            LoadSampleData();
            RefreshGrid();
        }

        private void LoadSampleData()
        {
            products.Add(new Laptop("VivoBook 15", "Asus", 35000, 10, "8GB", "Intel i5"));
            products.Add(new Smartphone("iPhone 14", "Apple", 55000, 5, 3279, 12));
            products.Add(new GamingLaptop("ROG Strix", "Asus", 75000, 3,
                "16GB", "AMD Ryzen 7", "RTX 3060", true));
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products.Select(p => new
            {
                Model = p.ModelName,
                Brand = p.Brand,
                Category = p.Category,
                Price = "₱" + p.Price.ToString("N0"),
                Stock = p.StockQuantity
            }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Customer viewer = new Customer("Guest", "guest", "guest123", "C001");
            var results = viewer.SearchProduct(products, txtSearch.Text);
            dataGridView1.DataSource = results.Select(p => new
            {
                Model = p.ModelName,
                Brand = p.Brand,
                Category = p.Category,
                Price = "₱" + p.Price.ToString("N0"),
                Stock = p.StockQuantity
            }).ToList();
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                if (index >= 0 && index < products.Count)
                {
                    manager.RestockProduct(products[index], 1);
                    RefreshGrid();
                    MessageBox.Show("Product restocked!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a product first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                if (index >= 0 && index < products.Count)
                {
                    if (products[index].StockQuantity > 0)
                    {
                        manager.SellProduct(products[index]);
                        RefreshGrid();
                        MessageBox.Show("Product sold!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Out of stock!", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}