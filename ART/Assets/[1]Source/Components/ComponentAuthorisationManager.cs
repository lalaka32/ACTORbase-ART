using Homebrew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BeeFly
{
    class ComponentAuthorisationManager : MonoCached
    {
        public void StartRegistration(string url, byte[] byteData)
        {
            StartCoroutine(PostUnityWebRequest(url, byteData));
        }
        public void StartLogin(string url, byte[] byteData)
        {
            StartCoroutine(PostUnityWebRequest(url, byteData));
        }

        IEnumerator PostUnityWebRequest(string url, byte[] byteData)
        {
            UnityWebRequest www = new UnityWebRequest(url, "POST");
            www.uploadHandler = new UploadHandlerRaw(byteData);
            DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();
            www.downloadHandler = downloadHandlerBuffer;
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete! Status Code: " + www.responseCode);
                string token = www.downloadHandler.text;
                Debug.Log(token);
                ProcessingSignals.Default.Send(new SignalToken(token));
            }
            
            www.Dispose();
        }

    }
}
