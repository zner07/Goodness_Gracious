using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechVault_Inventory_Management_System
{
    public abstract class User
    {
        private string _name;
        private string _username;
        private string _password;

        public string Name { get { return _name; } set { _name = value; } }
        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }

        public User(string name, string username, string password)
        {
            _name = name;
            _username = username;
            _password = password;
        }

        // Abstract method — each subclass must implement this
        public abstract bool Login(string username, string password);
    }
}
