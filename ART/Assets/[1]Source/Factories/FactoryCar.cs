﻿using System;
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
        
        public Transform SpawnCar(Vector3 pos, Quaternion rot, Transform parent, Direction[] directions)
        {
            var transform = this.Populate(Pool.None, prefabOfCar, pos, rot);
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
            //Direction rand = directions.Random();
            
            actorCar.direction.direction = Direction.Forward;
            actorCar.tags.Add(Tag.DirectionRight);
        }
    }
}
