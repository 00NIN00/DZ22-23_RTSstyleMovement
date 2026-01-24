using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Sound
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Button _changeSoundButton; 
        [SerializeField] private Button _changeMusicButton; 
        
        private AudioHandler _audioHandler;

        private void OnEnable()
        {
            _changeMusicButton.onClick.AddListener(_audioHandler.OnMusic);
            _changeSoundButton.onClick.AddListener(_audioHandler.OnSound);
        }

        public void Initialize(AudioHandler audioHandler)
        {
            _audioHandler = audioHandler;
        }

        private void OnDisable()
        {
            _changeMusicButton.onClick.RemoveListener(_audioHandler.OnMusic);
            _changeSoundButton.onClick.RemoveListener(_audioHandler.OnSound);
        }
    }
}