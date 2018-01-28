using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup menusContainer;
        [SerializeField] private CanvasGroup[] menus;
        [SerializeField] private CanvasGroup gameMenu;
        [SerializeField] private int startMenu = 0;
        [SerializeField] private Image playBtn;
        [SerializeField] private Sprite resume;

        private int currentMenu;

        public void StartGame()
        {
            MenuHelper.EnableCanvasGroup(menus[currentMenu], false);
            MenuHelper.EnableCanvasGroup(menusContainer, false);
            MenuHelper.EnableCanvasGroup(gameMenu, true);
            playBtn.sprite = resume;
        }

        public void SelectMenu(int selectedMenuIndex)
        {
            ShowSelectedMenu(selectedMenuIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void Start()
        {
            MenuHelper.EnableCanvasGroup(gameMenu, false);
            MenuHelper.EnableCanvasGroup(menusContainer, true);
            ShowSelectedMenu(startMenu);
        }

        private void ShowSelectedMenu(int selectedMenuIndex)
        {
            for (int i = 0; i < menus.Length; i++)
            {
                MenuHelper.EnableCanvasGroup(menus[i], false);
            }
            currentMenu = selectedMenuIndex;
            MenuHelper.EnableCanvasGroup(menus[currentMenu], true);
        }
    }
}