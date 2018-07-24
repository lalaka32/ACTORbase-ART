using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    [Serializable]
    public class DataCarTurnAnimations : IData,ISetup
    {
        public Animator animatorCarTurn;
        public void Dispose()
        {
            animatorCarTurn = null;
        }

        public void Setup(Actor actor)
        {
            animatorCarTurn = actor.selfTransform.GetComponentInChildren<Animator>();
        }
    }
}
