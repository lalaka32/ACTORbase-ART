using Homebrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BeeFly
{


    class ProcessingSecurity : ProcessingBase, IMustBeWipedOut
    {
        public ProcessingSecurity()
        {
            Homebrew.Timer.Add(0.1f, () => PlaySecurity());
        }

        private void PlaySecurity()
        {
            SecurityKey securityKey = new SecurityKey();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(Application.dataPath + "/" + "key.hui", FileMode.OpenOrCreate))
            {
                StreamReader reader = new StreamReader(stream);
                if (!string.IsNullOrEmpty(reader.ReadToEnd()))
                {
                    stream.Position = 0;
                    securityKey = (SecurityKey)formatter.Deserialize(stream);
                    if (SystemInfo.deviceUniqueIdentifier != securityKey.key)
                    {
                        Debug.Log("сасат");

                    }
                    else
                    {
                        Debug.Log("изи");
                    }
                }
                else
                {
                    securityKey.key = SystemInfo.deviceUniqueIdentifier;
                    formatter.Serialize(stream, securityKey);
                }
                Debug.Log("key=" + securityKey.key);
                Debug.Log("keyMetal=" + SystemInfo.deviceUniqueIdentifier);
            }
        }
    }
}
