using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeeFly
{
    public class UserRegistryModel
    {
        public string login;

        public string password;

        public string confirmPassword;

        public UserRegistryModel(string login, string password, string confirmPassword)
        {
            this.login = login;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }
    }
}
