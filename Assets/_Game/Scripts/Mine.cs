using UnityEngine;

namespace _Game.Scripts
{
    [RequireComponent(typeof(SphereCollider))]
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _damage;
        [SerializeField] private float _time;

        private Timer _timer;
        private HealthSystem _health;

        private void Awake()
        {
            _timer = new Timer();
            GetComponent<SphereCollider>().radius = _radius;
        }

        private void Update()
        {
            if (_timer.IsOver())
            {
                Explosion();
            }
            else
            {
                _timer.Update();
            }
        }

        private void Explosion()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out HealthSystem health))
                {
                    health.TakeDamage(_damage);
                }
            }

            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IMineTriggerable _))
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