using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class PauseHelper : MonoBehaviour
    {
        [SerializeField] private CanvasGroup gameCanvasGroup;
        [SerializeField] private CanvasGroup mainMenuCanvasGroup;
        [SerializeField] private MainMenu mainMenu;

        private bool pause = false;
        private bool allow = false;

        public void PauseHelperOff()
        {
            pause = false;
            allow = true;
        }

        private void Update()
        {
            if(allow == true && Input.GetKeyUp(KeyCode.Escape) == true)
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            pause = !pause;
            Time.timeScale = (pause == true) ? 0f : 1f;
            MenuHelper.EnableCanvasGroup(gameCanvasGroup, !pause);
            
            if(pause == true)
            {
                MenuHelper.EnableCanvasGroup(mainMenuCanvasGroup, true);
                mainMenu.SelectMenu(0);
            }
            else
            {
                mainMenu.StartGame();
            }
        }
    }
}

