using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWD.business_object
{
    class UsersInfo
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public UsersInfo(string Name, string Password)
        {
            this.Name = Name;
            this.Password = Password;
        }
    }
}
