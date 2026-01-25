using _Game.Scripts.Entity;
using UnityEngine;

namespace _Game.Scripts.View
{
    public class CharacterView : MonoBehaviour
    {
        private readonly int JumpKey = Animator.StringToHash("Jump");
        private readonly int JumpProcessKey = Animator.StringToHash("JumpProcess");
        private readonly int IsRunningKey = Animator.StringToHash("Speed");
        private readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        private readonly int IsDeath = Animator.StringToHash("IsDeath");

        private const float PercentWounded = 0.3f;
        private const int WeightOnLayer = 1;

        private const string InjuredLayer = "Injured";
        private int _injuredLayerIndex;


        private IHealthForView _healthForView;
        private AgentCharacter _character;

        private bool _isJump = false;
        
        [SerializeField] private Animator _animator;
        

        public void Initialize(AgentCharacter character, IHealthForView healthForView)
        {
            _character = character;
            _healthForView = healthForView;
            
            _injuredLayerIndex = _animator.GetLayerIndex(InjuredLayer);
        }

        private void Update()
        {
            if (_healthForView.IsAlive == false)
            {
                _animator.SetBool(IsDeath, true);

                return;
            }

            if (_healthForView.TakeDamageEvent())
                _animator.SetTrigger(TakeDamage);

            if (IsWounded(PercentWounded))
            {
                _animator.SetLayerWeight(_injuredLayerIndex, WeightOnLayer);
            }
            
            
            if (_character.InJumpProcess && _isJump == false)
            {
                Debug.Log("Jump");
                _animator.SetTrigger(JumpKey);
                _isJump = true;
            }

            if (_character.InJumpProcess == false)
            {
                _isJump = false;
            }
            
            _animator.SetBool(JumpProcessKey, _character.InJumpProcess);
            
            _animator.SetFloat(IsRunningKey, _character.CurrentVelocity.magnitude);
        }

        private bool IsWounded(float percent) => _healthForView.Value <= _healthForView.MaxValue * percent;
    }
}