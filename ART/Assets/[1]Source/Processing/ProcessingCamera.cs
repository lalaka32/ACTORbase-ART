using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingCamera : ProcessingBase, IReceive<SignalSpawnEnded>
    {
        [GroupBy(Tag.PlayerCar)]
        [GroupExclude(Tag.Dead)]
        Group playerCar;

        //Проблема: в группе 2 актёра походе не успевает удалиться а сигнал доходит
        //Нада задержка для сигнала наверн, но это странно потому что сигнал вызывается после удаления 
        public void HandleSignal(SignalSpawnEnded arg)
        {
            SetLocation(playerCar.actors[0].selfTransform, new Vector3(-20, 10, 0));
        }

        public void SetLocation(Transform transSneaking, Vector3 vector3)
        {
            GameObject cam = GameObject.Find("[KERNEL]/Cameras/camera_main");
            Vector3 backVector = transSneaking.forward * vector3.x;
            cam.transform.position = transSneaking.position + backVector;
            cam.transform.rotation = transSneaking.rotation;
        }
    }
}
