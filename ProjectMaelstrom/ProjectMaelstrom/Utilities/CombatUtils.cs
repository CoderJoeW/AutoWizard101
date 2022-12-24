using ProjectMaelstrom.Modules.ImageRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom.Utilities
{
    internal class CombatUtils : Util
    {
        public bool IsInBattle()
        {
            Point spellbook = _imageRecognition.GetImageLocation($"Resources/{Constants.RESOLUTION}/Combat/Utils/spellbook.png");

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

            string[] images = Directory.GetFiles($"Resources/{Constants.RESOLUTION}/Combat/Cards/{cardName}/");

            for (int i = 0; i < images.Length; i++)
            {
                if (!matchFound)
                {
                    Point card = _imageRecognition.GetImageLocation(images[i]);

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
            Point passBtn = _imageRecognition.GetImageLocation($"Resources/{Constants.RESOLUTION}/Combat/Utils/passbutton.png");

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
            Point passBtn = _imageRecognition.GetImageLocation($"Resources/{Constants.RESOLUTION}/Combat/Utils/passbutton.png");

            if (passBtn.X > 0 && passBtn.Y > 0)
            {
                WinAPI.click(passBtn);
            }
        }

        public void ResetCursor()
        {
            Point blankSpot = _imageRecognition.GetImageLocation($"Resources/{Constants.RESOLUTION}/Combat/Utils/blank.png");

            if (blankSpot.X > 0 && blankSpot.Y > 0)
            {
                _playerController.Click(blankSpot);
            }
            else
            {
                _playerController.Click(new Point(50, 20));
            }
        }

        public bool IsOutsideDungeon()
        {
            Point sigil = _imageRecognition.GetImageLocation($"Resources/{Constants.RESOLUTION}/Combat/Utils/sigil.png");

            if (sigil.X > 0 && sigil.Y > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
