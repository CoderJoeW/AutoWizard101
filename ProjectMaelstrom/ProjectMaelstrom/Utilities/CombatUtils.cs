﻿using ProjectMaelstrom.Modules.ImageRecognition;

namespace ProjectMaelstrom.Utilities;

internal class CombatUtils : Util
{
    public bool IsInBattle()
    {
        Point? spellbook = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Combat/Utils/spellbook.png");

        if (spellbook.HasValue)
        {
            return false;
        }

        return true;
    }

    public bool UseCard(string cardName)
    {
        bool matchFound = false;

        string[] images = Directory.GetFiles($"{StorageUtils.GetAppPath()}/Combat/Cards/{cardName}/");

        for (int i = 0; i < images.Length; i++)
        {
            if (!matchFound)
            {
                Point? card = ImageFinder.RetrieveTargetImagePositionInScreenshot(images[i]);

                if (card.HasValue)
                {
                    _playerController.Click(card.Value);
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
        Point? passBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Combat/Utils/passbutton.png");

        if (passBtn.HasValue)
        {
            return true;
        }

        return false;
    }

    public void Pass()
    {
        Point? passBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Combat/Utils/passbutton.png");

        if (passBtn.HasValue)
        {
            WinAPI.click(passBtn.Value);
        }
    }

    public bool IsOutsideDungeon()
    {
        Point? sigil = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Combat/Utils/sigil.png");

        if (sigil.HasValue)
        {
            return true;
        }

        return false;
    }
}
