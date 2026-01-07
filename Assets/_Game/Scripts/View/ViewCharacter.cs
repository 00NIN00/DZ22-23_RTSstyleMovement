using UnityEngine;

namespace _Game.Scripts.View
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
        
        private IMoveView _moveView;
        private IHealthView _healthView;


        public void Initialize(IMoveView moveView, IHealthView healthView)
        {
            _moveView = moveView;
            _healthView = healthView;
            
            _injuredLayerIndex = _animator.GetLayerIndex(_injuredLayer);
        }

        private void Update()
        {
            if (_healthView.IsAlive == false)
            {
                _animator.SetBool(IsDeath, true);
                
                return;
            }
            
            if (_healthView.TakeDamageEvent())
                _animator.SetTrigger(TakeDamage);

            
            
            if (IsWounded(PercentWounded))
            {
                _animator.SetLayerWeight(_injuredLayerIndex, WeightOnLayer);
            }
            
            _animator.SetFloat(Speed, _moveView.Speed);
        }

        private bool IsWounded(float percent) => _healthView.Health <= _healthView.MaxHealth * percent;
    }
}