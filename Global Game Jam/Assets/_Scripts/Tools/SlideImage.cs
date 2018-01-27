using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GlobalGameJam
{
    public class SlideImage : MonoBehaviour
    {
        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public delegate void OnSlidingComplete();
        public event OnSlidingComplete onSlidingComplete;

        [SerializeField] private Direction directionToMove;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private bool show = false;
        [SerializeField] private float width;
        [SerializeField] private float height;

        private float hidePosition;
        private float showPosition = 0f;

        public void ToggleSlideVFX(float slideTime)
        {
            show = !show;
            SlideVFX(slideTime);
        }

        public void GoToSlideVFX(bool enable, float slideTime)
        {
            show = enable;
            SlideVFX(slideTime);
        }

        private void Start()
        {
            SetDirectionAnchors();
        }

        private void SlideVFX(float slideTime)
        {
            if (directionToMove == Direction.UP || directionToMove == Direction.DOWN)
            {
                SlideGUIYAxis(slideTime);
            }
            else
            {
                SlideGUIXAxis(slideTime);
            }
        }

        private void SlideGUIYAxis(float slideTime)
        {
            if (show == true) {
                rectTransform.DOAnchorPosY(showPosition, slideTime).OnComplete(SlideComplete);
            } else {
                rectTransform.DOAnchorPosY(hidePosition, slideTime);
            }
        }

        private void SlideGUIXAxis(float slideTime)
        {
            if (show == true) {
                rectTransform.DOAnchorPosX(showPosition, slideTime).OnComplete(SlideComplete);
            } else {
                rectTransform.DOAnchorPosX(hidePosition, slideTime);
            }
        }

        private void SlideComplete()
        {
            if(onSlidingComplete != null) {
                onSlidingComplete();
            }
        }

        private void SetDirectionAnchors()
        {
            float pos;

            switch (directionToMove)
            {
                case Direction.UP:
                    hidePosition = height;
                    pos = (show == true) ? showPosition : hidePosition;
                    rectTransform.anchorMin = new Vector2(0, 1);
                    rectTransform.anchorMax = new Vector2(1, 1);
                    rectTransform.pivot = new Vector2(0.5f, 1f);
                    rectTransform.anchoredPosition = new Vector3(0f, pos, 0f);
                    rectTransform.offsetMin = new Vector2(0, 0f);
                    rectTransform.offsetMax = new Vector2(0f, height);
                    SlideGUIYAxis(0.1f);
                    break;
                case Direction.DOWN:
                    hidePosition = height * -1;
                    pos = (show == true) ? showPosition : hidePosition;
                    rectTransform.anchorMin = new Vector2(0, 0);
                    rectTransform.anchorMax = new Vector2(1, 0);
                    rectTransform.pivot = new Vector2(0.5f, 0f);
                    rectTransform.anchoredPosition = new Vector3(0f, pos, 0f);
                    rectTransform.offsetMin = new Vector2(0, 0f);
                    rectTransform.offsetMax = new Vector2(0f, height);
                    SlideGUIYAxis(0.1f);
                    break;
                case Direction.LEFT:
                    hidePosition = width * -1;
                    pos = (show == true) ? showPosition : hidePosition;
                    rectTransform.anchorMin = new Vector2(0, 0);
                    rectTransform.anchorMax = new Vector2(0, 1);
                    rectTransform.pivot = new Vector2(0f, 0.5f);
                    rectTransform.anchoredPosition = new Vector3(pos, 0f, 0f);
                    rectTransform.offsetMin = new Vector2(0, 0f);
                    rectTransform.offsetMax = new Vector2(width, 0f);
                    SlideGUIXAxis(0.1f);
                    break;
                case Direction.RIGHT:
                    hidePosition = width;
                    pos = (show == true) ? showPosition : hidePosition;
                    rectTransform.anchorMin = new Vector2(1, 0);
                    rectTransform.anchorMax = new Vector2(1, 1);
                    rectTransform.pivot = new Vector2(1f, 0.5f);
                    rectTransform.anchoredPosition = new Vector3(pos, 0f, 0f);
                    rectTransform.offsetMin = new Vector2(0, 0f);
                    rectTransform.offsetMax = new Vector2(width, 0f);
                    SlideGUIXAxis(0.1f);
                    break;
                default: break;
            }
        }
    }
}

