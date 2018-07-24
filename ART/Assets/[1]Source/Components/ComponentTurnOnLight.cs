using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ComponentTurnOnLight :MonoCached
    {
        protected override void HandleEnable()
        {
            GetComponent<Animator>().SetBool("isOn", true);
        }
    }
}
