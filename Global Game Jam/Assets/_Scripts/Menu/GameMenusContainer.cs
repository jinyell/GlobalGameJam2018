using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class GameMenusContainer : MonoBehaviour
    {
        [System.Serializable]
        public class GameMenu
        {
            public enum GameScene
            {
                CLASSROOM,
                DESK,
                BEDROOM,
                CAFETERIA,
                PHONE,
                HALLWAY
            }

            public GameScene gameScene;
            public CanvasGroup canvasGroup;
        }

        [SerializeField] private CanvasGroup gamesMenuContainer;
        [SerializeField] private GameMenu[] gameMenus;
        [SerializeField] private GameMenu.GameScene startMenu;

        private GameMenu.GameScene currentScene;

        public void SelectMenu(GameMenu.GameScene gameScene)
        {
            ShowSelectedMenu(gameScene);
        }

        private void Start()
        {
            MenuHelper.EnableCanvasGroup(gamesMenuContainer, true);
            ShowSelectedMenu(startMenu);
        }

        private void ShowSelectedMenu(GameMenu.GameScene selectedMenu)
        {
            for (int i = 0; i < gameMenus.Length; i++)
            {
                MenuHelper.EnableCanvasGroup(gameMenus[i].canvasGroup, false);
            }
            currentScene = selectedMenu;
            MenuHelper.EnableCanvasGroup(gameMenus[(int)currentScene].canvasGroup, true);
        }
    }
}