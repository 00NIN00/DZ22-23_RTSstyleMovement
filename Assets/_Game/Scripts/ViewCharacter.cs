using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class ViewCharacter : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        [SerializeField] private Animator _animator;
        
        private IAnimatorMove _animatorMove;
        private IAnimatorHealth _animatorHealth;


        public void Initialize(IAnimatorMove animatorMove, IAnimatorHealth animatorHealth)
        {
            _animatorMove = animatorMove;
            _animatorHealth = animatorHealth;

            Debug.Log(_animatorMove);
        }

        private void Update()
        {
            if (_animatorHealth.TakeDamageTrigger())
                _animator.SetTrigger(TakeDamage);


            _animator.SetFloat(Speed, _animatorMove.Speed);
        }
    }
}