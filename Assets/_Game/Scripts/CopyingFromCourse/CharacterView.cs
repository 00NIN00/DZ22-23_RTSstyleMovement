using _Game.Scripts.View;
using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public class CharacterView : MonoBehaviour
    {
        private readonly int IsRunningKey = Animator.StringToHash("Speed");
        private readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        private readonly int IsDeath = Animator.StringToHash("IsDeath");

        private const float PercentWounded = 0.3f;
        private const int WeightOnLayer = 1;

        private const string InjuredLayer = "Injured";
        private int _injuredLayerIndex;


        private IHealthView _healthView;
        private AgentCharacter _character;
        [SerializeField] private Animator _animator;

        public void Initialize(AgentCharacter character, IHealthView healthView)
        {
            _character = character;
            _healthView = healthView;
            
            _injuredLayerIndex = _animator.GetLayerIndex(InjuredLayer);
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

            _animator.SetFloat(IsRunningKey, _character.CurrentVelocity.magnitude);
        }

        private bool IsWounded(float percent) => _healthView.Value <= _healthView.MaxValue * percent;
    }
}