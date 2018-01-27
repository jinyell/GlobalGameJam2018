using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public class ChoicesGUI : MonoBehaviour
    {
        [SerializeField] private Button pencil;
        [SerializeField] private SimplePulse pulse;

        public void AllowChoiceInteraction(bool enable)
        {
            pencil.interactable = enable;
            pulse.EnablePulse(enable);
        }

    }
}
