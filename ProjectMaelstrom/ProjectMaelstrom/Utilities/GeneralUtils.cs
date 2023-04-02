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
        private static GeneralUtils? _instance;

        public static GeneralUtils Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GeneralUtils();
                }

                return _instance;
            }
        }

        private Random _random = new Random();

        public void SetMarker()
        {
            Point? marker = ImageFinder.GetCoordsOfImage($"{StorageUtils.GetAppPath()}/Combat/Utils/marklocation.png");

            if (marker.HasValue)
            {
                _playerController.Click(marker.Value);
            }
        }

        public bool Teleport()
        {
            Point? teleport = ImageFinder.GetCoordsOfImage($"{StorageUtils.GetAppPath()}/Combat/Utils/teleportto.png");

            if (teleport.HasValue)
            {
                _playerController.Click(teleport.Value);
                return true;
            }

            return false;
        }

        public async void GetUserMana()
        {
            string imgKey = RandomString(20);
            string imgPath = $"screenshots/{imgKey}.png";

            _imageRecognition.TakeScreenshot(imgKey);

            OcrResultModel result = await ImageToText.GetStringsFromImage("test.png");

            List<string> splitText = result.ParsedResults[0].ParsedText.Split("\n").ToList();

            for (int i = 0; i < splitText.Count; i++)
            {
                if (splitText[i] == "MANA")
                {
                    StateManager.Instance.raw = splitText[i + 2];

                    string[] mana = StateManager.Instance.raw.Split("/");

                    StateManager.Instance.CurrentMana = mana[0];
                    StateManager.Instance.MaxMana = mana[1];

                    return;
                }
            }
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
