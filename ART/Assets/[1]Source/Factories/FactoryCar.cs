using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    [CreateAssetMenu(fileName = "FactoryCar", menuName = "Factories/FactoryCar")]
    class FactoryCar : Factory
    {
        [SerializeField]
        GameObject prefabOfCar;

        public List<Transform> Cars { get; private set; } = new List<Transform>();

        System.Random rand = new System.Random();

        public Transform SpawnCar(Vector3 pos, Quaternion rot, Transform parent, Direction[] directions)
        {
            var transform = this.Populate(Pool.Entities, prefabOfCar, pos, rot);
            transform.parent = parent;
            Cars.Add(transform);
            if (prefabOfCar.GetComponent<ActorCar>() != null)
            {
                SetCarWithRandomData(transform.GetComponent<ActorCar>(),directions);
            }
            return transform;
        }
        //Пока рандом слабенький можно накрутить его покруче 
        //Нужно думать
        public void SetCarWithRandomData(ActorCar actorCar, Direction[] directions)
        {
            //Возможно лучше не сувать это в тэг, а сделать процессинг
            //в котором указать верные позиции. Теги для указания 
            //Состояния объекта а не для указания позиций
            Direction rand = directions.Random();
            actorCar.direction = (rand);
            //Debug.Log((actorCar.direction-1).ToString());
            actorCar.tags.Add((int)rand+ 50);
            //actorCar.tags.Add(actorCar.Get<DataPosition>().position);//Исправить

            //actorCar.Add<DataFinalPosition>().finPosition =
            //actorCar.Get<DataDirection>().direction + actorCar.Get<DataPosition>().position;
            //actorCar.tags.Add(actorCar.Get<DataFinalPosition>().finPosition);
        }
    }
}
