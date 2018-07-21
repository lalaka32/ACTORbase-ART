using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Homebrew;

namespace BeeFly
{
    [Serializable]
    public class DataTurnerPositions : IData
    {
        public Transform frontLeft;
        public Transform frontRight;
        public Transform backLeft;
        public Transform backRight;

        public void Dispose()
        {
            frontLeft = null;
            frontRight = null;
            backLeft = null;
            backRight = null;
        }
    }
}
