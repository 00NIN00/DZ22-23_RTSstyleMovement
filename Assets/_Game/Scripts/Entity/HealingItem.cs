using _Game.Scripts.HealthSystem;
using UnityEngine;

namespace _Game.Scripts.Entity
{
    public class HealingItem : MonoBehaviour
    {
        [SerializeField] private float _healAmount;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IHealable healable))
            {
                healable.Heal(_healAmount);
                Destroy(gameObject);
            }
        }
    }
}