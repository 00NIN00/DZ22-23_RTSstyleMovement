using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private Caster _caster;
        [SerializeField] private Character _character;
        [SerializeField] private Transform _flagTransform;
        [SerializeField] private ViewCharacter _viewCharacter;
        [SerializeField] private HealthSystem _healthSystem;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _caster.Initialize(new Input(), _character, _flagTransform);
            
            var agentMover = new AgentMover(_navMeshAgent);
            _character.Initialize(agentMover, agentMover);
            
            _viewCharacter.Initialize(_character.AnimatorMove, _healthSystem);
        }
    }
}