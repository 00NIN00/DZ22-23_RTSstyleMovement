using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class ViewCharacter : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        private static readonly int IsDeath = Animator.StringToHash("IsDeath");

        [SerializeField] private Animator _animator;
        
        private IAnimatorMove _animatorMove;
        private IAnimatorHealth _animatorHealth;


        public void Initialize(IAnimatorMove animatorMove, IAnimatorHealth animatorHealth)
        {
            _animatorMove = animatorMove;
            _animatorHealth = animatorHealth;
        }

        private void Update()
        {
            if (_animatorHealth.IsAlive == false)
            {
                _animator.SetBool(IsDeath, true);
                
                return;
            }
            
            if (_animatorHealth.TakeDamageTrigger())
                _animator.SetTrigger(TakeDamage);
            
            
            _animator.SetFloat(Speed, _animatorMove.Speed);
        }
    }
}