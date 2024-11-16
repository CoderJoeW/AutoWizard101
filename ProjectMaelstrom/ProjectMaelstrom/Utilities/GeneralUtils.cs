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
using Tesseract;

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
            Point? marker = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Combat/Utils/marklocation.png");

            if (marker.HasValue)
            {
                _playerController.Click(marker.Value);
            }
        }

        public bool Teleport()
        {
            Point? teleport = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Combat/Utils/teleportto.png");

            if (teleport.HasValue)
            {
                _playerController.Click(teleport.Value);
                return true;
            }

            return false;
        }

        public void OpenGameWindow()
        {
            Point? gameWindowIcon = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/General/window_taskbar_icon.png");

            if(gameWindowIcon.HasValue)
            {
                _playerController.Click(gameWindowIcon.Value);
            }
        }

        public void OpenStatsWindow()
        {
            Point? spellbookIcon = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/General/spellbook.png");

            if (spellbookIcon.HasValue)
            {
                _playerController.Click(spellbookIcon.Value);
            }
        }

        public bool IsGameVisible()
        {
            Point? windowVisible = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/General/window_header.png");

            if (windowVisible.HasValue)
            {
                return true;
            }

            return false;
        }

        public bool IsStatsPageVisible()
        {
            Point? statsPageVisible = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/General/spellbook_homepage.png");

            if (statsPageVisible.HasValue)
            {
                return true;
            }

            return false;
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public void ResetCursorPosition()
        {
            Point? blankSpot = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/General/blank.png");

            if (blankSpot.HasValue)
            {
                _playerController.Click(blankSpot.Value);
                return;
            }

            _playerController.Click(new Point(50, 20));
        }
    }
}
