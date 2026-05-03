using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVault_Inventory_Management_System
{
    public class GamingLaptop : Laptop
    {
        private string _gpu;
        private bool _rgbSupport;

        public string Gpu { get { return _gpu; } set { _gpu = value; } }
        public bool RgbSupport { get { return _rgbSupport; } set { _rgbSupport = value; } }

        public GamingLaptop(string modelName, string brand, decimal price, int stock,
                            string ram, string processor, string gpu, bool rgb)
            : base(modelName, brand, price, stock, ram, processor)
        {
            _gpu = gpu;
            _rgbSupport = rgb;
            Category = "Gaming Laptop";
        }

        public override string GetSpecs()
        {
            return base.GetSpecs() + $"\nGPU: {_gpu}\nRGB Support: {(_rgbSupport ? "Yes" : "No")}";
        }
    }
}
