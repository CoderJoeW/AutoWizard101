using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom.Utilities
{
    internal class StorageUtils
    {
        public static string GetAppPath()
        {
            return $"Resources/{StateManager.Instance.SelectedResolution}";
        }
    }
}
