using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;
using UnityEngine;

namespace BeeFly
{
    class ProcessingStaticPositions : ProcessingBase, IMustBeWipedOut
    {
        public static ProcessingStaticPositions Default;

        public List<FactorySituation> staticSituations;

        public List<Situation> Get(int tag)
        {
            foreach (var item in staticSituations)
            {
                if (item.tagSituation == tag)
                {
                    return item.Cases;
                }
            }
            return null;
        }
        public void SetTypeOfCross(int type)
        {
            Toolbox.Get<DataArtSession>().typeOfCross = type;
        }
        public List<Situation> GetRandom(params int[] tags)
        {
            return Get(tags[Random.Range(0, tags.Length)]);
        }
    }
}
