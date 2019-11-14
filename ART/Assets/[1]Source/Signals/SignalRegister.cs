using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeeFly
{
    struct SignalRegister
    {
        public GameObject prefabOfRegisterUserName;
        public GameObject prefabOfRegisterUserPassword;
        public GameObject prefabOfRegisterUserConfirmPassword;

        public SignalRegister(GameObject prefabOfRegisterUserName, GameObject prefabOfRegisterUserPassword, GameObject prefabOfRegisterUserConfirmPassword)
        {
            this.prefabOfRegisterUserName = prefabOfRegisterUserName;
            this.prefabOfRegisterUserPassword = prefabOfRegisterUserPassword;
            this.prefabOfRegisterUserConfirmPassword = prefabOfRegisterUserConfirmPassword;
        }
    }
}
