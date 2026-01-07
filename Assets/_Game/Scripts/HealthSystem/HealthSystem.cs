using _Game.Scripts.View;
using UnityEngine;

namespace _Game.Scripts.HealthSystem
{
    public class HealthSystem : MonoBehaviour, IDamageable, IHealable, IAnimatorHealth
    {
        [SerializeField] private float _maxHealth;
        private float _health;
        
        private bool _isTakeDamage;
        
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public bool IsAlive => _health > 0;

        public void Initialize(float maxHealth)
        {
            _maxHealth = maxHealth;
            _health = _maxHealth;
        }

        private void Update()
        {
            Debug.Log("Health: " + _health);
        }

        public void TakeDamage(float damage)
        {
            if(damage <= 0)
                return;
            
            _health -= damage;
            _isTakeDamage = true;

            if (_health <= 0)
                _health = 0;
        }

        public void Heal(float heal)
        {
            if(heal <= 0) 
                return;
            
            _health += heal;

            if (_health >= 0)
                _health = _maxHealth;
        }

        public bool TakeDamageEvent()
        {
            if (_isTakeDamage)
            {
                _isTakeDamage = false;
                return true;
            }
            
            return false;
        }
    }
}