using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingCamera :ProcessingBase
    {
        [GroupBy(Tag.PlayerCar)]
        Group playerCar;
        
        public ProcessingCamera()
        {  
            Homebrew.Timer.Add(0.5f,()=>SetLocation(playerCar.actors[0].selfTransform, new Vector3(-20, 10, 0)));
        }
        public void SetLocation(Transform transSneaking, Vector3 vector3)
        {
            var cam = Camera.main;
            //Debug.Log();
            cam.gameObject.transform.position = new Vector3(0, 0, 0);
            Vector3 backVector = transSneaking.forward * vector3.x;
            cam.transform.position = transSneaking.position + backVector + (vector3.y * Vector3.up);
            cam.transform.eulerAngles = transSneaking.localEulerAngles;
        }
    }
}
