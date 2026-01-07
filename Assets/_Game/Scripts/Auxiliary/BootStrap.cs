using _Game.Scripts.Entity;
using _Game.Scripts.MoveSystem;
using _Game.Scripts.View;
using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts.Auxiliary
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private Caster _caster;
        [SerializeField] private Transform _flagTransform;
        [Header("Character")]
        [SerializeField] private Character _character;
        [SerializeField] private float _maxHealth;
        [SerializeField] private HealthSystem.HealthViewSystem healthViewSystem;
        [Header("Components")]
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private ViewCharacter _viewCharacter;

        private void Awake()
        {
            healthViewSystem.Initialize(_maxHealth);
            
            var agentMover = new AgentMover(_navMeshAgent);
            _character.Initialize(agentMover, agentMover, healthViewSystem);
            
            _caster.Initialize(new Input(), _character);
            
            _viewCharacter.Initialize(_character.MoveView, healthViewSystem);
        }
    }
}