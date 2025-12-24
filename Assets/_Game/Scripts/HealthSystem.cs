using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class HealthSystem : MonoBehaviour, IAnimatorHealth
    {
        [SerializeField] private float _maxHealth;
        private float _health;
        
        private bool _isTakeDamage;
        
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public bool IsAlive => _health > 0;
        
        private void Awake()
        {
            _health = _maxHealth;
        }

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

        public bool TakeDamageTrigger()
        {
            if (_isTakeDamage)
            {
                _isTakeDamage = false;
                return true;
            }
            
            return false;
        }
    }

    public interface IAnimatorHealth
    {
        bool TakeDamageTrigger();
    }
}