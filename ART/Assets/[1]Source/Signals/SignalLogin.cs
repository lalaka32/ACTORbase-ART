using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeeFly
{
    struct SignalLogin
    {
        public GameObject prefabOfLoginUserName;
        public GameObject prefabOfLoginUserPassword;

        public SignalLogin(GameObject prefabOfLoginUserName, GameObject prefabOfLoginUserPassword)
        {
            this.prefabOfLoginUserName = prefabOfLoginUserName;
            this.prefabOfLoginUserPassword = prefabOfLoginUserPassword;
        }
    }
}
