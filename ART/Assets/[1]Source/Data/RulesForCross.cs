using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    class RulesForCross : IData
    {
        public List<FactoryRules> rulesLeftDirection = new List<FactoryRules>();
        public List<FactoryRules> rulesForwardDirection = new List<FactoryRules>();
        public List<FactoryRules> rulesRightDirection = new List<FactoryRules>();
        public void Dispose()
        {
            rulesLeftDirection = null;
            rulesForwardDirection = null;
            rulesRightDirection = null;
        }
        public List<FactoryRules> SelectRules(int dir)
        {
            switch (dir)
            {
                case Direction.Right:
                    return rulesRightDirection;
                case Direction.Forward:
                    return rulesForwardDirection;
                case Direction.Left:
                    return rulesLeftDirection;
                default:
                    return null;
            }
        }
    }
}
