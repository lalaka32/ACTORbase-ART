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
    class FactoryCar : Homebrew.Factory
    {
        [SerializeField]
        GameObject prefabOfCar;

        public List<Transform> Cars { get; private set; } = new List<Transform>();

        public Transform SpawnCar(Vector3 pos, Quaternion rot, Transform parent, int direction)
        {
            var transformCar = this.Populate(Pool.None, prefabOfCar, pos, rot);
            ActorCar actorCar = transformCar.GetComponent<ActorCar>();
            transformCar.parent = parent;
            Cars.Add(transformCar);
            SetCarWithRandomData(actorCar, direction);
            //бля не ебу поч тут нада делать таймер
            Homebrew.Timer.Add(0.1f, () => actorCar.signals.Send(new SignalSetLights()));
            return transformCar;
        }


        public void SetCarWithRandomData(ActorCar actorCar, int direction)
        {
            //Direction rand = directions.Random();

            actorCar.dataDirection.direction = direction;
        }
    }
}
