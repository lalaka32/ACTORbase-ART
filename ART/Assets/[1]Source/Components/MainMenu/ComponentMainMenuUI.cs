using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

namespace BeeFly
{
    class ComponentMainMenuUI : MonoCached
    {
        public GameObject prefabOfSettings;

        public GameObject prefabOfRegularity;

        public GameObject prefabOfUnqvalent;

        public GameObject prefabOfLogin;

        public GameObject prefabOfRegister;

        public InputField prefabOfLoginUserName;

        public InputField prefabOfLoginUserPassword;

        public InputField prefabOfRegisterUserName;

        public InputField prefabOfRegisterUserPassword;

        public InputField prefabOfRegisterUserConfirmPassword;

        public void Play()
        {
            Scenes.Cross.To();
        }

        protected override void HandleEnable()
        {
            prefabOfSettings.active = false;
            var type = Toolbox.Get<DataChances>().defaultType;
            switch (type)
            {
                case TypeOfCross.Regularity:
                    prefabOfRegularity.GetComponent<Toggle>().isOn = true;
                    break;
                case TypeOfCross.UnQvalent:
                    prefabOfUnqvalent.GetComponent<Toggle>().isOn = true;
                    break;
            }
        }

        public void OpenCrossSettings()
        {
            prefabOfSettings.active = true;
        }

        public void CloseCrossSettings()
        {
            prefabOfSettings.active = false;
        }

        public void OpenLogin()
        {
            prefabOfLogin.active = true;
        }

        public void CloseLogin()
        {
            prefabOfLogin.active = false;
        }

        public void OpenRegister()
        {
            prefabOfRegister.active = true;
        }

        public void CloseRegister()
        {
            prefabOfRegister.active = false;
        }

        public void SetRegularity(bool turn)
        {
            Toolbox.Get<DataChances>().defaultType = TypeOfCross.Regularity;
            prefabOfUnqvalent.GetComponent<Toggle>().isOn = false;
        }

        public void SetUnqvalent(bool turn)
        {
            Toolbox.Get<DataChances>().defaultType = TypeOfCross.UnQvalent;
            prefabOfRegularity.GetComponent<Toggle>().isOn = false;
        }
        public void Login()
        {
            ProcessingSignals.Default.Send(new SignalLogin(prefabOfLoginUserName, prefabOfLoginUserPassword));
        }

        public void Register()
        {
            ProcessingSignals.Default.Send(new SignalRegister(prefabOfRegisterUserName, prefabOfRegisterUserPassword, prefabOfRegisterUserConfirmPassword));
        }
    }
}
