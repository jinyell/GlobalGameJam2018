using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    [RequireComponent (typeof(AudioSource))]
    public class AudioHelper : MonoBehaviour
    {
        [SerializeField] private AudioClip[] music;

        private AudioSource audioSource;

        public void PlayGamePlayMusic()
        {
            audioSource.loop = false;
            audioSource.Stop();
            PlayRandomNextSong();
        }

        private void Awake()
        {
            audioSource = this.GetComponent<AudioSource>();
        }

        private void Start()
        {
            PlayIntroSong();
        }

        private void PlayIntroSong()
        {
            audioSource.clip = music[0];
            audioSource.loop = true;
            audioSource.Play();
        }

        private void PlayRandomNextSong()
        {
            audioSource.clip = music[Random.Range(1, music.Length)];
            audioSource.Play();
            Invoke("PlayNextSong", audioSource.clip.length);
        }
    }
}