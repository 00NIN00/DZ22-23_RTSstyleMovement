using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.AudioSystem
{
    public class AudioHandlerView : MonoBehaviour
    {
        [SerializeField] private Button _changeSoundButton; 
        [SerializeField] private Button _changeMusicButton; 
        
        private AudioHandler _audioHandler;

        private void OnEnable()
        {
            _changeMusicButton.onClick.AddListener(ChangeMusic);
            _changeSoundButton.onClick.AddListener(ChangeSound);
        }

        public void Initialize(AudioHandler audioHandler)
        {
            _audioHandler = audioHandler;
        }

        private void ChangeMusic()
        {
            if (_audioHandler.IsMusicOn())
            {
                _audioHandler.OffMusic();
            }
            else
            {
                _audioHandler.OnMusic();
            }
        }


        private void ChangeSound()
        {
            if (_audioHandler.IsSoundOn())
            {
                _audioHandler.OffSound();
            }
            else
            {
                _audioHandler.OnSound();
            }
        }

        private void OnDisable()
        {
            _changeMusicButton.onClick.AddListener(ChangeMusic);
            _changeSoundButton.onClick.AddListener(ChangeSound);
        }
    }
}