using _Game.Scripts.AudioSystem;
using _Game.Scripts.Auxiliary;
using _Game.Scripts.Entity;
using UnityEngine;
using UnityEngine.Audio;

namespace _Game.Scripts.View
{
    public class BombView : MonoBehaviour
    {
        [SerializeField] private Bomb _bomb;

        [Header("Particle")]
        [SerializeField] private ParticleSystem _boomParticleSystem;
        [Header("Audio")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        private AudioPlayer _audioPlayer;
        private AnimatorScale _animatorScale;
        private bool _isFirstExploded;

        private void Start()
        {
            _audioPlayer = new AudioPlayer();
            _animatorScale = new AnimatorScale(transform.localScale, transform);
        }

        private void Update()
        {
            if (_bomb.IsProcess)
            {
                _animatorScale.Update(Time.time);
            } 
            
            if (_bomb.IsExplored &&  !_isFirstExploded)
            {
                _isFirstExploded = true;
                
                var particle = Instantiate(_boomParticleSystem, transform.position, Quaternion.identity);
                particle.Play();
                
                _audioPlayer.Play(_audioClip, transform, _audioMixerGroup);

                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}