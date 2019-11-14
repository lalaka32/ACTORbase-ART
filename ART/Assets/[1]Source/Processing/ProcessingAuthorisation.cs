using Homebrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeFly
{
    class ProcessingAuthorisation : ProcessingBase, IReceive<SignalLogin>, IReceive<SignalRegister>
    {
        public void HandleSignal(SignalLogin arg)
        {
            throw new NotImplementedException();
        }

        public void HandleSignal(SignalRegister arg)
        {
            throw new NotImplementedException();
        }
    }
}
