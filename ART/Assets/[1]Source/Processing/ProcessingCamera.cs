using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingCamera : ProcessingBase, IReceive<SignalSetCamera>
    {
        [GroupBy(Tag.PlayerCar)]
        [GroupExclude(Tag.Dead)]
        Group playerCar;

        [GroupBy(Tag.SpawnCamPosition)]
        Group CamSpawnSpot;

        float speed;

        public ProcessingCamera()
        {
            speed = 1f;
        }
        //Проблема: в группе 2 актёра походе не успевает удалиться а сигнал доходит
        //Нада задержка для сигнала наверн, но это странно потому что сигнал вызывается после удаления 
        GameObject camGO;
        public void HandleSignal(SignalSetCamera arg)
        {
            camGO = GameObject.Find("[KERNEL]/Cameras/camera_main");
            if (playerCar.length != 0)
            {
                SetLocation(playerCar.actors[0].selfTransform, new Vector3(-20, 10, 0));
                //SetSniperPosirion(CamSpawnSpot.actors.ReturnRandom().selfTransform, playerCar.actors[0].selfTransform);
            }
        }
        void SetSniperPosirion(Transform pos, Transform toSneak)
        {
            camGO.transform.position = pos.position;
            camGO.transform.LookAt(toSneak);
        }
        public void SetLocation(Transform transSneaking, Vector3 vector3)
        {
            camGO.transform.LookAt(transSneaking);
            Vector3 backVector = transSneaking.forward * vector3.x;
            backVector.y += vector3.y;
            camGO.transform.position = transSneaking.position + backVector;
            camGO.transform.rotation = transSneaking.rotation;
        }

        Camera camera;
        public float sensitivity = 1F;
        public float maxRotation = 45f;
        public float selfRot = 0;
        void RotateCamWithClick()
        {
            if (Input.GetMouseButton(1))
            {
                camera = camGO.GetComponent<Camera>();
                var MousePos = Input.mousePosition;
                float MyAngle = 0;
                // расчитываем угол, как:
                // разница между позицией мышки и центром экрана, делённая на размер экрана
                //  (чем дальше от центра экрана тем сильнее поворот)
                // и умножаем угол на чуствительность из параметров

                MyAngle = sensitivity * ((MousePos.x - (Screen.width / 2)) / Screen.width);
                if (Math.Abs(selfRot) < 45f)
                {
                    camera.transform.RotateAround(camGO.transform.position, camera.transform.up, MyAngle);
                    selfRot += MyAngle;
                }
                else
                {
                    if (selfRot > 0)
                    {
                        if (MyAngle < 0)
                        {
                            selfRot += MyAngle;
                        }
                    }
                    else
                    {
                        if (MyAngle > 0)
                        {
                            selfRot += MyAngle;
                        }
                    }
                }
                Debug.Log(selfRot);
                //MyAngle = -sensitivity * ((MousePos.y - (Screen.height / 2)) / Screen.height);
                //camera.transform.RotateAround(camGO.transform.position, camera.transform.up, MyAngle);

            }
        }
    }
}
