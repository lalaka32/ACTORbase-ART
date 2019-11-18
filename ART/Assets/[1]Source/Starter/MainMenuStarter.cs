using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew;

namespace BeeFly
{
    class MainMenuStarter : Homebrew.Starter
    {
        [FoldoutGroup("SetupData")] public List<DataGame> DatesGame = new List<DataGame>();

        protected override void Setup()
        {
            for (int i = 0; i < DatesGame.Count; i++)
            {
                Toolbox.Add(DatesGame[i]);
            }
            Toolbox.Add<ProcessingAuthorisation>();

        }
    }
}
