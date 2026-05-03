using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVault_Inventory_Management_System
{
    public class Smartphone : Product
    {
        private int _batteryCapacity;
        private int _cameraMP;

        public int BatteryCapacity { get { return _batteryCapacity; } set { _batteryCapacity = value; } }
        public int CameraMP { get { return _cameraMP; } set { _cameraMP = value; } }

        public Smartphone(string modelName, string brand, decimal price, int stock,
                          int battery, int cameraMP)
            : base(modelName, brand, price, stock, "Smartphone")
        {
            _batteryCapacity = battery;
            _cameraMP = cameraMP;
        }

        public override string GetSpecs()
        {
            return $"Battery: {_batteryCapacity}mAh\nCamera: {_cameraMP}MP";
        }
    }
}
