using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom
{
    internal class StateManager
    {
        private static StateManager? _instance;

        public static StateManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance= new StateManager();
                }

                return _instance;
            }
        }

        public string? SelectedResolution { set; get; }

        public string CurrentMana { set; get; }
        public string MaxMana { set; get; }
        
        public int SetMarkerCost { set; get; }

        public string raw { set; get; }
    }
}
