using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public static class MenuHelper
    {
        public  static void EnableCanvasGroup(CanvasGroup canvasGroup, bool enable)
        {
            canvasGroup.alpha = (enable == true) ? 1f : 0f;
            canvasGroup.interactable = enable;
            canvasGroup.blocksRaycasts = enable;
            canvasGroup.ignoreParentGroups = enable;
        }
    }
}

