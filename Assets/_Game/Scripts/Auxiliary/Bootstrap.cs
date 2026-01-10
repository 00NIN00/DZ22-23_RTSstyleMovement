using _Game.Scripts.CopyingFromCourse;
using _Game.Scripts.Entity;
using _Game.Scripts.HealthSystem;
using _Game.Scripts.View;
using UnityEngine.AI;
using UnityEngine;

namespace _Game.Scripts.Auxiliary
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ViewTargetPointCharacter _viewTargetPointCharacter;
        [SerializeField] private Flag _flag;
        [Header("Character")]
        [SerializeField] private AgentCharacter _character;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _speedRotate;
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private ControllerUpdater _controllerUpdater;
        
        [Header("Components")]
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private CharacterView _viewCharacter;

        private void Awake()
        {
            var playerHealth = new Health(_maxHealth);
            
            _character.Initialize(playerHealth, _navMeshAgent, _speedMove, _speedRotate);

            var moveController = new DestinationController(new Input(), _character, _layerMask);
            var rotateController = new AlongMovableDestinationRotatableController(_character, _character);
            _controllerUpdater.Initialize(moveController, rotateController);
            
            _viewTargetPointCharacter.Initialize(_character, _flag);
            _viewCharacter.Initialize(_character, playerHealth);
        }
    }
}