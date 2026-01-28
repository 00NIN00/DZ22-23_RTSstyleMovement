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
            GameObject tempAudio = CreateObject(transform);
            
            AudioSource audioSource = CreateAudioSource(tempAudio, mixerGroup);
            audioSource.PlayOneShot(audioClip);
            
            DestroyByTime(tempAudio, audioClip.length);
        }

        private GameObject CreateObject(Transform transform)
        {
            GameObject gameObject = new GameObject("TempAudio");
            gameObject.transform.position = transform.position;
            
            return gameObject;
        }

        private AudioSource CreateAudioSource(GameObject tempAudio, AudioMixerGroup mixerGroup)
        {
            AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
            audioSource.pitch = Random.Range(PitchMin, PitchMax);
            audioSource.outputAudioMixerGroup = mixerGroup;
            
            return audioSource;
        }

        private void DestroyByTime(GameObject gameObject, float time)
        {
            Destroyer destroyer = gameObject.AddComponent<Destroyer>();
            destroyer.Initialize(time);
        }
    }
}