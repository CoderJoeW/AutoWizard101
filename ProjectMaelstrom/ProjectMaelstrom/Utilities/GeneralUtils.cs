using ProjectMaelstrom.Modules.ImageRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom.Utilities
{
    internal class GeneralUtils: Util
    {
        public void SetMarker()
        {
            Point marker = _imageRecognition.GetImageLocation($"Resources/{Constants.RESOLUTION}/Combat/Utils/marklocation.png");

            if (marker.X > 0 && marker.Y > 0)
            {
                _playerController.Click(marker);
            }
        }

        public bool Teleport()
        {
            Point teleport = _imageRecognition.GetImageLocation($"Resources/{Constants.RESOLUTION}/Combat/Utils/teleportto.png");

            if (teleport.X > 0 && teleport.Y > 0)
            {
                _playerController.Click(teleport);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
