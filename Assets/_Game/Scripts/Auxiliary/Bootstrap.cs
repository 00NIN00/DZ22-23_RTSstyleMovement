using _Game.Scripts.AudioSystem;
using _Game.Scripts.Controllers;
using _Game.Scripts.CopyingFromCourse;
using _Game.Scripts.Entity;
using _Game.Scripts.HealthSystem;
using _Game.Scripts.MoveSystem;
using _Game.Scripts.SpawnSystem;
using _Game.Scripts.View;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Audio;

namespace _Game.Scripts.Auxiliary
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ViewTargetPointCharacter _viewTargetPointCharacter;
        [SerializeField] private Flag _flag;
        
        [SerializeField] private SpawnerHandler _spawner;
        
        [Header("Character")]
        [SerializeField] private AgentCharacter _character;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _speedRotate;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private ControllerUpdater _controllerUpdater;
        
        [Header("Components")]
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private CharacterView _viewCharacter;
        
        [Header("Audio")]
        [SerializeField] private AudioHandlerView audioHandlerView;
        [SerializeField] private AudioMixer _audioMixer;
        private AudioHandler _audioHandler;

        private void Awake()
        {
            var playerInput = new Input();
            var playerHealth = new Health(_maxHealth);
            
            _character.Initialize(playerHealth, _navMeshAgent, _speedMove, _speedRotate, _jumpSpeed, _jumpCurve);

            _spawner.Initialize(new Spawner(_character.transform, _spawner),  playerInput);
            
            var moveController = new DestinationController(playerInput, _character, _layerMask, _character, _character);
            var rotateController = new AlongMovableDestinationRotatableController(_character, _character);
            _controllerUpdater.AddEntity(moveController);
            
            _viewTargetPointCharacter.Initialize(_character, _flag);
            _viewCharacter.Initialize(_character);

            _audioHandler = new AudioHandler(_audioMixer);
            audioHandlerView.Initialize(_audioHandler);
        }
    }
}