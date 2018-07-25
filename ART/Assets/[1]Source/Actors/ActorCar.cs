using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{ 
    public class ActorCar : Actor
    {
        //public DataBlueprint blueprint;

        [FoldoutGroup("Setup")] public DataPriority daraPriority;
        [FoldoutGroup("Setup")] public DataDirection dataDirection;
        [FoldoutGroup("Setup")] public DataTurnerPositions dataTurnerPositions;
        [FoldoutGroup("Setup")] public DataCarTurnAnimations dataCarTurnAnimations;
        [FoldoutGroup("Setup")] public DataComperativeCars dataComperativeCars;

        protected override void OnBeforeDestroy()
        {
            OnDisable();
        }

        protected override void SetupData()
        {
            Add(daraPriority);
            Add(dataDirection);
            Add(dataComperativeCars);
            Add(dataTurnerPositions);
            Add(dataCarTurnAnimations);
            tags.Add(Tag.Car);
        }

        protected override void SetupBehaviors()
        {
            Add<BehaviorDeath>();
            Add<BehaviorPriority>();
            Add<BehaviorTurnOnLight>();
            Add<BehaviorAnimation>();
            Add<BehaviorCarViewPriority>();
            //Homebrew.Timer.Add(0.25f, () => AddDebug());
        }
        //void AddDebug()
        //{
        //    if (Toolbox.Get<DataScene>().debugMode)
        //    {
        //        Add<BehaviorCarViewPriority>();
        //    }
        //}
    }
}
