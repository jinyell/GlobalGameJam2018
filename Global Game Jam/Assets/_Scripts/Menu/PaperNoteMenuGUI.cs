using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public class PaperNoteMenuGUI : MonoBehaviour
    {
        public delegate void OnChoiceSelected(int choiceSelectIndex);
        public event OnChoiceSelected onChoiceSelected;

        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private GameObject choicesContainer;
        [SerializeField] private CanvasGroup choicesCanvasGroup;
        
        public void ShowPaperNoteOptions()
        {
           string[] createChoices = new string[2] { "Eh you know...", "Swell... How are you?" };
           CreateChoices(createChoices);
        }

        public void SelectButton(GameObject buttonSelect)
        {
            MenuHelper.EnableCanvasGroup(choicesCanvasGroup, false);

            if(onChoiceSelected != null)
            {
                int selectIndex = System.Int32.Parse(buttonSelect.name);
                onChoiceSelected(selectIndex);
            }
        }

        public void CreateChoices(string[] dialogueChoices)
        {
            for (int i = 0; i < dialogueChoices.Length; i++)
            {
                GameObject choiceButton = (GameObject)GameObject.Instantiate(buttonPrefab) as GameObject;
                Text choice = choiceButton.GetComponentInChildren<Text>();
                choiceButton.name = i.ToString();
                choice.text = dialogueChoices[i];
                choiceButton.transform.SetParent(choicesContainer.transform);
                choiceButton.transform.localScale = Vector3.one;
                choiceButton.transform.localEulerAngles = Vector3.zero;
                choiceButton.transform.localPosition = new Vector3(choiceButton.transform.localPosition.x, choiceButton.transform.localPosition.y, 0f);
                choiceButton.SetActive(true);
            }
            MenuHelper.EnableCanvasGroup(choicesCanvasGroup, true);
        }
    }
}