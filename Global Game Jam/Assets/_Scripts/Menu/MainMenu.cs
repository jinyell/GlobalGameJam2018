using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup mainMenu;

        public void StartGame()
        {
            MenuHelper.EnableCanvasGroup(mainMenu, false);
        }

        private void Start()
        {
            MenuHelper.EnableCanvasGroup(mainMenu, true);
        }
    }
}