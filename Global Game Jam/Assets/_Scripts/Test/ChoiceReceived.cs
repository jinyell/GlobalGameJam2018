using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ChoiceReceived : MonoBehaviour
    {
        [SerializeField] private PaperNoteMenuGUI paperMenuGUI;

        public void ChoiceSelected(int choiceIndex)
        {
            Debug.Log("The choice index chosen is: " + choiceIndex);
        }

        private void OnEnable()
        {
            paperMenuGUI.onChoiceSelected += ChoiceSelected;
        }

        private void OnDisable()
        {
            paperMenuGUI.onChoiceSelected -= ChoiceSelected;
        }
    }
}