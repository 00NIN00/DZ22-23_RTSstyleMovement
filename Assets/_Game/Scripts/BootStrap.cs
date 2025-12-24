using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private Caster _caster;
        [SerializeField] private Transform _flagTransform;
        [Header("Character")]
        [SerializeField] private Character _character;
        [SerializeField] private float _maxHealth;
        [SerializeField] private HealthSystem _healthSystem;
        [Header("Components")]
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private ViewCharacter _viewCharacter;

        private void Awake()
        {
            _caster.Initialize(new Input(), _character, _flagTransform);
            _healthSystem.Initialize(_maxHealth);
            
            var agentMover = new AgentMover(_navMeshAgent);
            _character.Initialize(agentMover, agentMover, _healthSystem);
            
            _viewCharacter.Initialize(_character.AnimatorMove, _healthSystem);
        }
    }
}