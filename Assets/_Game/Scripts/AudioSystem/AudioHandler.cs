using UnityEngine;
using UnityEngine.Audio;

namespace _Game.Scripts.AudioSystem
{
    public class AudioHandler
    {
        private const float OffVolumeValue = -80.0f;
        private const float OnVolumeValue = 0f;
        
        private const string MusicKey = "music";
        private const string SoundKey = "sound";
        
        private readonly AudioMixer _audioMixer;

        public AudioHandler(AudioMixer audioMixer)
        {
            _audioMixer = audioMixer;
        }

        public bool IsMusicOn() => IsVolumeOn(MusicKey);
        public bool IsSoundOn() => IsVolumeOn(SoundKey);
        
        public void OnMusic() => OnVolume(MusicKey);
        public void OffMusic() => OffVolume(MusicKey);
        
        public void OnSound() => OnVolume(SoundKey);
        public void OffSound() => OffVolume(SoundKey);
        
        private bool IsVolumeOn(string key) => _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - OnVolumeValue) < 0.01f;
        
        private void OnVolume(string key) => _audioMixer.SetFloat(key, OnVolumeValue);
        private void OffVolume(string key) => _audioMixer.SetFloat(key, OffVolumeValue);
    }
}