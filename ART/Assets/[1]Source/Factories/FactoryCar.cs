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

        public Transform SpawnCar(Vector3 pos, Quaternion rot, Transform parent, Direction[] directions)
        {
            var transformCar = this.Populate(Pool.None, prefabOfCar, pos, rot);
            ActorCar actorCar = transformCar.GetComponent<ActorCar>();
            transformCar.parent = parent;
            Cars.Add(transformCar);
            SetCarWithRandomData(actorCar, directions);
            //бля не ебу поч тут нада делать таймер
            Homebrew.Timer.Add(0.1f, () => actorCar.signals.Send(new SignalSetLights()));
            return transformCar;
        }


        public void SetCarWithRandomData(ActorCar actorCar, Direction[] directions)
        {
            //Direction rand = directions.Random();

            actorCar.dataDirection.direction = UnityEngine.Random.Range(0,3);
        }
    }
}
