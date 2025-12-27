using UnityEngine;

namespace _Game.Scripts
{
    public class ViewCharacter : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        private static readonly int IsDeath = Animator.StringToHash("IsDeath");
        private const float PercentWounded = 0.3f;
        private const int WeightOnLayer = 1;
        private readonly string _injuredLayer = "Injured"; 
        private int _injuredLayerIndex;
        
        [SerializeField] private Animator _animator;
        
        private IAnimatorMove _animatorMove;
        private IAnimatorHealth _animatorHealth;


        public void Initialize(IAnimatorMove animatorMove, IAnimatorHealth animatorHealth)
        {
            _animatorMove = animatorMove;
            _animatorHealth = animatorHealth;
            
            _injuredLayerIndex = _animator.GetLayerIndex(_injuredLayer);
        }

        private void Update()
        {
            if (_animatorHealth.IsAlive == false)
            {
                _animator.SetBool(IsDeath, true);
                
                return;
            }
            
            if (_animatorHealth.TakeDamageEvent())
                _animator.SetTrigger(TakeDamage);

            
            
            if (IsWounded(PercentWounded))
            {
                _animator.SetLayerWeight(_injuredLayerIndex, WeightOnLayer);
            }
            
            _animator.SetFloat(Speed, _animatorMove.Speed);
        }

        private bool IsWounded(float percent) => _animatorHealth.Health <= _animatorHealth.MaxHealth * percent;
    }
}