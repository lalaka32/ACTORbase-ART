﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Toggle = UnityEngine.UI.Toggle;

namespace BeeFly
{
    class ComponentMainMenuUI : MonoCached
    {
        public GameObject prefabOfSettings;

        public GameObject prefabOfRegularity;

        public GameObject prefabOfUnqvalent;

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
    }
}