using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVault_Inventory_Management_System
{
    public class Laptop : Product
    {
        private string _ram;
        private string _processor;

        public string Ram { get { return _ram; } set { _ram = value; } }
        public string Processor { get { return _processor; } set { _processor = value; } }

        public Laptop(string modelName, string brand, decimal price, int stock,
                      string ram, string processor)
            : base(modelName, brand, price, stock, "Laptop")
        {
            _ram = ram;
            _processor = processor;
        }

        public override string GetSpecs()
        {
            return $"Processor: {_processor}\nRAM: {_ram}";
        }
    }
}
