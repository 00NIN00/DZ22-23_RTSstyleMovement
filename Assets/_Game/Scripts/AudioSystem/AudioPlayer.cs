using _Game.Scripts.Auxiliary;
using UnityEngine.Audio;
using UnityEngine;

namespace _Game.Scripts.AudioSystem
{
    public class AudioPlayer
    {
        private const float PitchMin = 0.8f;
        private const float PitchMax = 1.2f;

        public void Play(AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.pitch = Random.Range(PitchMin, PitchMax);
            audioSource.PlayOneShot(audioClip);
        }
        
        public void Play(AudioClip audioClip, Transform transform, AudioMixerGroup mixerGroup)
        {
            GameObject tempAudio = new GameObject("TempAudio");
            tempAudio.transform.position = transform.position;
    
            AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
            audioSource.pitch = Random.Range(PitchMin, PitchMax);
            audioSource.outputAudioMixerGroup = mixerGroup;
            audioSource.PlayOneShot(audioClip);
            
            Destroyer destroyer = tempAudio.AddComponent<Destroyer>();
            destroyer.Initialize(audioClip.length);
        }
    }
}