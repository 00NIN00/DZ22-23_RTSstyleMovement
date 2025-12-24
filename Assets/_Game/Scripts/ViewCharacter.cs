using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class ViewCharacter : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private HealthSystem _healthSystem;

        private void Update()
        {
            if (_healthSystem.IsAlive && _healthSystem.Health < _healthSystem.MaxHealth * 0.3)
            {
                
            }
        }
    }
}