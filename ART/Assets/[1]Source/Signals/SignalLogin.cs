using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BeeFly
{
    struct SignalLogin
    {
        public InputField prefabOfLoginUserName;
        public InputField prefabOfLoginUserPassword;

        public SignalLogin(InputField prefabOfLoginUserName, InputField prefabOfLoginUserPassword)
        {
            this.prefabOfLoginUserName = prefabOfLoginUserName;
            this.prefabOfLoginUserPassword = prefabOfLoginUserPassword;
        }
    }
}
