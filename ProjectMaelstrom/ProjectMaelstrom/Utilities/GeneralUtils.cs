using ProjectMaelstrom.Modules.ImageRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ProjectMaelstrom.Models;

using Newtonsoft.Json;
using System.Windows.Forms;

namespace ProjectMaelstrom.Utilities
{
    internal class GeneralUtils: Util
    {
        private Random _random = new Random();

        public void SetMarker()
        {
            Point marker = _imageRecognition.GetImageLocation($"{StorageUtils.GetAppPath()}/Combat/Utils/marklocation.png");

            if (marker.X > 0 && marker.Y > 0)
            {
                _playerController.Click(marker);
            }
        }

        public bool Teleport()
        {
            Point teleport = _imageRecognition.GetImageLocation($"{StorageUtils.GetAppPath()}/Combat/Utils/teleportto.png");

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

        public async void GetUserMana()
        {
            string imgKey = RandomString(20);
            string imgPath = $"screenshots/{imgKey}.png";

            _imageRecognition.TakeScreenshot(imgKey);

            LazarusResultModel lazarusResultModel = JsonConvert.DeserializeObject<LazarusResultModel>(await ImageToText.GetStringsFromImage(imgPath));

            foreach (ProjectMaelstrom.Models.KeyValuePair kvp in lazarusResultModel.keyValuePairs)
            {
                if (kvp.key.content == "MANA")
                {
                    string manaString = kvp.value.content;

                    string[] mana = manaString.Split('/');

                    StateManager.Instance.CurrentMana = int.Parse(mana[0]);
                    StateManager.Instance.MaxMana = int.Parse(mana[1]);
                }
            }

            File.Delete(imgPath);
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
