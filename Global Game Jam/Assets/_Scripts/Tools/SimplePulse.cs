using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GlobalGameJam
{
    [RequireComponent (typeof(Image))]
    public class SimplePulse : MonoBehaviour
    {
        private const float QUICK_RESET_TIME = 0.5f;
        
        [SerializeField] private Color startColor;
        [SerializeField] private Color pulseColor;
        [SerializeField] private bool pulsing = false;
        [SerializeField] private float pulseTime = 2.5f;

        private Image pulseImage;

        public void EnablePulse(bool enable)
        {
            pulsing = enable;

            if(pulsing == false) {
                QuickReset();
            } else {
                Pulsing();
            }
        }

        public void QuickReset()
        {
            pulsing = false;
            pulseImage.DOKill();
            pulseImage.DOColor(startColor, QUICK_RESET_TIME);
        }

        private void Start()
        {
            pulseImage = this.GetComponent<Image>();
            EnablePulse(pulsing);
        }
        
        private void Pulsing()
        {
            pulseImage.DOColor(pulseColor, pulseTime).SetLoops(-1, LoopType.Yoyo);
        }
    }
}