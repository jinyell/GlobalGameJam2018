using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public class ScriptManager : MonoBehaviour
    {
        public FlashingImage butterflyImage;
        GameMenusContainer gmc;
        SceneBrancher sb;
        JsonReader jr;

        public TextAsset[] Scenes;
        public TextAsset[] Language;

        void Start()
        {
            gmc = GetComponent<GameMenusContainer>();
            jr = GetComponent<JsonReader>();
            sb = GetComponent<SceneBrancher>();
        }

        void Butterfly()
        {
            StartCoroutine(fadeButterfly());
        }

        IEnumerator fadeButterfly()
        {
            butterflyImage.alpha = 0;
            for(int i = 0; i < 50; ++i)
            {
                butterflyImage.alpha += 0.02f;
                yield return new WaitForSeconds(0.005f);
            }
            for (int i = 0; i < 50; ++i)
            {
                butterflyImage.alpha -= 0.02f;
                yield return new WaitForSeconds(0.005f);
            }
            butterflyImage.alpha = 0;
        }

        void BeginDay2()
        {
            jr.Game = Scenes[1];
            jr.Language = Language[1];
            jr.Init();
            sb.displayScene(sb.currentScene);
        }

        void BeginDay3()
        {
            jr.Game = Scenes[2];
            jr.Language = Language[2];
            jr.Init();
            sb.displayScene(sb.currentScene);
        }

        void BeginDay4()
        {
            jr.Game = Scenes[3];
            jr.Language = Language[3];
            jr.Init();
            sb.displayScene(sb.currentScene);
        }

        void BeginDay5()
        {
            jr.Game = Scenes[4];
            jr.Language = Language[4];
            jr.Init();
            sb.displayScene(sb.currentScene);
        }

        void ShowClassroom()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }

        void ShowDesk()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.DESK);
        }

        void ShowBedroom()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.BEDROOM);
        }

        void ShowCafeteria()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CAFETERIA);
        }

        void ShowPhone()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.PHONE);
        }

        void ShowHallway()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.HALLWAY);
        }
        void ShowArcade()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.ARCADE);
        }
        void ShowLivingRoom()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.LIVING_ROOM);
        }
        void ShowAsh()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.ASH);
        }
        void ShowMax()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.MAX);
        }
    }
}
