using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom
{
    internal class StateManager
    {
        public string SelectedResolution { set; get; }

        public int CurrentMana { set; get; }
        public int MaxMana { set; get; }
        
        public int SetMarkerCost { set; get; }
    }
}
