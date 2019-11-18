using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BeeFly
{
    struct SignalRegister
    {
        public InputField prefabOfRegisterUserName;
        public InputField prefabOfRegisterUserPassword;
        public InputField prefabOfRegisterUserConfirmPassword;

        public SignalRegister(InputField prefabOfRegisterUserName, InputField prefabOfRegisterUserPassword, InputField prefabOfRegisterUserConfirmPassword)
        {
            this.prefabOfRegisterUserName = prefabOfRegisterUserName;
            this.prefabOfRegisterUserPassword = prefabOfRegisterUserPassword;
            this.prefabOfRegisterUserConfirmPassword = prefabOfRegisterUserConfirmPassword;
        }
    }
}
