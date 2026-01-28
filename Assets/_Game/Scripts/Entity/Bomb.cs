using _Game.Scripts.HealthSystem;
using _Game.Scripts.Auxiliary;
using UnityEngine;

namespace _Game.Scripts.Entity
{
    [RequireComponent(typeof(SphereCollider))]
    public class Bomb : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _radius;
        [SerializeField] private float _damage;
        [SerializeField] private float _time;
        
        private bool _isExplored;
        private Timer _timer;
        
        public bool IsExplored => _isExplored;
        public bool IsProcess => _timer.IsProcess;

        private void Awake()
        {
            _timer = new Timer(this);
            GetComponent<SphereCollider>().radius = _radius;
        }

        private void Update()
        {
            if (_timer.IsOver())
            {
                Explosion();
            }
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
            //gameObject.SetActive(false);
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