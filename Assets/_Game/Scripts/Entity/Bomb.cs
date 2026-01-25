using _Game.Scripts.Auxiliary;
using _Game.Scripts.HealthSystem;
using UnityEngine;

namespace _Game.Scripts.Entity
{
    [RequireComponent(typeof(SphereCollider))]
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _damage;
        [SerializeField] private float _time;
        [SerializeField] private ParticleSystem _boomParticleSystem;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        private bool _isExplored;
        private Timer _timer;
        
        private AudioPlayer _audioPlayer;
        
        private AnimatorScale _animatorScale;

        private void Awake()
        {
            _timer = new Timer(this);
            GetComponent<SphereCollider>().radius = _radius;

            _animatorScale = new AnimatorScale(transform.localScale, transform);

            _audioPlayer = new AudioPlayer(_audioSource);
        }

        private void Update()
        {
            if (_timer.IsOver())
            {
                Explosion();
            }

            if (_timer.IsProcess)
            {
                _animatorScale.Update(Time.time);
            }
            
            if (!_boomParticleSystem.isPlaying && _isExplored)
                gameObject.SetActive(false);
        }

        private void Explosion()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(_damage);
                }
            }
            
            _isExplored =  true;
            
            _boomParticleSystem.Play();
            _audioPlayer.Play(_audioClip);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IMineTriggerable _) && _isExplored == false)
            {
                _timer.TryStart(_time);
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}