using UnityEngine;

namespace _Game.Scripts.HealthSystem
{
    public class Health
    {
        private readonly float _maxValue;
        private float _value;
        
        private bool _isTakeDamage;
        
        public float Value => _value;
        public float MaxValue => _maxValue;
        public bool IsAlive => _value > 0;


        public Health(float maxValue)
        {
            _maxValue = maxValue;
            _value = _maxValue;
        }
        
        public bool CanRemove(float damage)
        {
            if (damage <= 0)
                return false;
            
            if (_value - damage < 0)
                return false;
            
            return true;
        }
        
        public void Remove(float damage)
        {
            if (CanRemove(damage) == false)
                return;
            
            _value -= damage;
            _isTakeDamage = true;

            if (_value <= 0)
                _value = 0;
            
            Debug.Log(_value);
        }

        public void Add(float heal)
        {
            if(heal <= 0) 
                return;
            
            _value += heal;

            if (_value >= 0)
                _value = _maxValue;
            
            Debug.Log(_value);
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