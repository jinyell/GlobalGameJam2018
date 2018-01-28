using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            public Sprite scenery;
        }

        [SerializeField] private CanvasGroup gamesMenuContainer;
        [SerializeField] private GameMenu[] gameScenes;
        [SerializeField] private Image backgroundImage;
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
            currentScene = selectedMenu;
            backgroundImage.sprite = gameScenes[(int)currentScene].scenery;
        }
    }
}