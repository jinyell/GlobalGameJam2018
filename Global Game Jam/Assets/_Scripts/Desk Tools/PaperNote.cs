using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
    public class PaperNote : MonoBehaviour
    {
        private const float CHARACTER_DELAY_TIME = 0.05f;

        [SerializeField] private Text paperNote;
        [SerializeField] private SlideImage slideImage;
        [SerializeField] private string currentNote;
        public string CurrentNote { set { currentNote = value; } }

        public void SetPaperNote()
        {
            StartCoroutine(SetNote(currentNote));
        }

        public void ErasePaperNote()
        {
            paperNote.text = "";
        }

        private IEnumerator SetNote(string message)
        {
            paperNote.text = "";
            for (int i = 0; i < message.Length; i++)
            {
                paperNote.text += message[i];
                yield return new WaitForSeconds(CHARACTER_DELAY_TIME);
            }
        }

        private void WritingPaperNote()
        {
            StartCoroutine(SetNote(currentNote));
        }

        private void Awake()
        {
            paperNote.text = "";
        }

        private void OnEnable()
        {
            slideImage.onSlidingComplete += WritingPaperNote;
        }

        private void OnDisable()
        {
            slideImage.onSlidingComplete -= WritingPaperNote;
        }
    }
}