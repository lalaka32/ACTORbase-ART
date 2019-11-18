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
    class ProcessingAuthorisation : ProcessingBase, IReceive<SignalLogin>, IReceive<SignalRegister>
    {
        //private static readonly HttpClient client;
        ComponentAuthorisationManager authManager = GameObject.Find("[KERNEL]/AuthorisationManager").GetComponent<ComponentAuthorisationManager>();


        private string BASE_URL = "http://localhost:2054/api/Auth/";
        private float WAIT_TIMEOUT = 10.0f;

        public delegate void ResultCallback(bool error, string data);
        public void HandleSignal(SignalLogin arg)
        {
            throw new NotImplementedException();
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



    }
}
