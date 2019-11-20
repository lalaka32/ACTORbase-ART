using Homebrew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BeeFly
{
    class ProcessingAuthorisation : ProcessingBase, IReceive<SignalLogin>, IReceive<SignalRegister>, IReceive<SignalToken>, IMustBeWipedOut
    {
        //private static readonly HttpClient client;
        ComponentAuthorisationManager authManager = GameObject.Find("[KERNEL]/AuthorisationManager").GetComponent<ComponentAuthorisationManager>();
        string token = Toolbox.Get<DataGameSession>().Token;

        private string BASE_URL = "http://localhost:2054/api/Auth/";
        private float WAIT_TIMEOUT = 10.0f;

        public delegate void ResultCallback(bool error, string data);
        public void HandleSignal(SignalLogin arg)
        {
            string userName = arg.prefabOfLoginUserName.text;
            string password = arg.prefabOfLoginUserPassword.text;

            UserLoginModel loginModel = new UserLoginModel(userName, password);

            string jsonLoginModel = JsonUtility.ToJson(loginModel);
            byte[] byteData = System.Text.Encoding.ASCII.GetBytes(jsonLoginModel.ToCharArray());

            authManager.StartLogin(BASE_URL + "Login", byteData);
        }

        public void HandleSignal(SignalRegister arg)
        {
            string userName = arg.prefabOfRegisterUserName.text;
            string password = arg.prefabOfRegisterUserPassword.text;
            string confirmPassword = arg.prefabOfRegisterUserConfirmPassword.text;

            UserRegistryModel registryModel = new UserRegistryModel(userName, password, confirmPassword);

            string jsonRegistryModel = JsonUtility.ToJson(registryModel);
            byte[] byteData = System.Text.Encoding.ASCII.GetBytes(jsonRegistryModel.ToCharArray());

            authManager.StartRegistration(BASE_URL + "Register", byteData);
        }

        public void HandleSignal(SignalToken arg)
        {
            token = JsonUtility.FromJson<TokenModel>(arg.token).token;
            Debug.Log("token now is: " + token);
            ProcessingSignals.Default.Send(new SignalHideAuth());

        }

    }
}
