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

        void Start()
        {
            gmc = GetComponent<GameMenusContainer>();
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

        }

        void ShowClassroom()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }

        void ShowDesk()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }

        void ShowBedroom()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }

        void ShowCafeteria()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }

        void ShowPhone()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }

        void ShowHallway()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }
        void ShowArcade()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }
        void ShowLivingRoom()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }
        void ShowClassroom5()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }
        void ShowAsh()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }
        void ShowMax()
        {
            gmc.SelectMenu(GameMenusContainer.GameMenu.GameScene.CLASSROOM);
        }
    }
}
