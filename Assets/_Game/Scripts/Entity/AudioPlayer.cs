using UnityEngine;

namespace _Game.Scripts.Entity
{
    public class AudioPlayer
    {
        private const float PitchMin = 0.8f;
        private const float PitchMax = 1.2f;
        
        private readonly AudioSource _audioSource;

        public AudioPlayer(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void Play(AudioClip audioClip)
        {
            _audioSource.pitch = Random.Range(PitchMin, PitchMax);
            _audioSource.PlayOneShot(audioClip);
        }
    }
}