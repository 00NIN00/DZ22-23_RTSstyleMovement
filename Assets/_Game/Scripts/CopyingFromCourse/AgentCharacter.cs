using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts.CopyingFromCourse
{
    public class AgentCharacter  : MonoBehaviour
    {
        private NavMeshAgent _agent;
        
        private AgentMover _mover;
        private DirectionRotator _rotator;
        
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        
        [SerializeField] private Transform _target;
        
        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        
        public Quaternion CurrentRotation => _rotator.CurrentRotation;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;

            _mover = new AgentMover(_agent, _moveSpeed);
            _rotator = new DirectionRotator(_agent.transform, _rotateSpeed);
        }
        
        
    }
}