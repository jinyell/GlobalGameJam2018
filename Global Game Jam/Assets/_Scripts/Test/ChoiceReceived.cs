using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class ChoiceReceived : MonoBehaviour
    {
        [SerializeField] private MenuGUI menuGUI;

        public void ChoiceSelected(int choiceIndex)
        {
            Debug.Log("The choice index chosen is: " + choiceIndex);
        }

        private void OnEnable()
        {
            menuGUI.onChoiceSelected += ChoiceSelected;
        }

        private void OnDisable()
        {
            menuGUI.onChoiceSelected -= ChoiceSelected;
        }
    }
}