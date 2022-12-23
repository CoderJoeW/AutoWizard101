using ProjectMaelstrom.Modules.ImageRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom
{
    internal class CombatUtils
    {
        private ImageRecognition _image_recognition = new ImageRecognition();
        private PlayerController _playerController = new PlayerController();

        public bool IsInBattle()
        {
            Point spellbook = _image_recognition.GetImageLocation($"{Constants.RESOLUTION}/Combat/Utils/spellbook.png");

            if (spellbook.X > 0 && spellbook.Y > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UseCard(string cardName)
        {
            bool matchFound = false;

            string[] images = Directory.GetFiles($"{Constants.RESOLUTION}/Combat/Cards/{cardName}/");

            for (int i = 0; i < images.Length; i++)
            {
                if (!matchFound)
                {
                    Point card = _image_recognition.GetImageLocation(images[i]);

                    if (card.X > 0 && card.Y > 0)
                    {
                        _playerController.Click(card);
                        matchFound = true;
                    }
                    else
                    {
                        matchFound = false;
                    }
                }
            }

            return matchFound;
        }

        public bool IsMyTurn()
        {
            Point passBtn = _image_recognition.GetImageLocation($"{Constants.RESOLUTION}/Combat/Utils/passbutton.png");

            if (passBtn.X > 0 && passBtn.Y > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Pass()
        {
            Point passBtn = _image_recognition.GetImageLocation($"{Constants.RESOLUTION}/Combat/Utils/passbutton.png");

            if (passBtn.X > 0 && passBtn.Y > 0)
            {
                WinAPI.click(passBtn);
            }
        }

        public void ResetCursor()
        {
            Point blankSpot = _image_recognition.GetImageLocation($"{Constants.RESOLUTION}/Combat/Utils/blank.png");

            if (blankSpot.X > 0 && blankSpot.Y > 0)
            {
                _playerController.Click(blankSpot);
            }
            else
            {
                _playerController.Click(new Point(50, 20));
            }
        }
    }
}
