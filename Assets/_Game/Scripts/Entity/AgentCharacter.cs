using _Game.Scripts.Auxiliary;
using _Game.Scripts.HealthSystem;
using _Game.Scripts.MoveSystem;
using _Game.Scripts.RotateSystem;
using UnityEngine.AI;
using UnityEngine;

namespace _Game.Scripts.Entity
{
    public class AgentCharacter : MonoBehaviour, IMineTriggerable, IDamageable, IDirectionalRotatable, IDestinationMovable, IHealable
    {
        private NavMeshAgent _agent;
        
        private AgentMover _mover;
        private DirectionRotator _rotator;
        
        private float _moveSpeed;
        private float _rotateSpeed;
        
        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        
        public Vector3 TargetMovePosition => _agent.destination;
        public bool IsFinishing => !_agent.pathPending && !_agent.hasPath && _agent.remainingDistance <= _agent.stoppingDistance;

        private Health _health;

        public void Initialize(Health health,  NavMeshAgent agent, float moveSpeed, float rotateSpeed)
        {
            _health = health;
            _agent = agent;

            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;

            _agent.updateRotation = false;

            _mover = new AgentMover(_agent, _moveSpeed);
            _rotator = new DirectionRotator(_agent.transform, _rotateSpeed);
        }

        private void Update()
        {
            _rotator.Update(Time.deltaTime);
            
            if (_health.IsAlive == false)
            {
                StopMoving();
                return;
            }
        }
        
        public void SetDestination(Vector3 position) => _mover.SetDestination(position);
        public void SetRotateDirection(Vector3 inputDirection) => _rotator.SetDirection(inputDirection);
        
        public void ResumeMoving() =>  _mover.Resume();
        public void StopMoving() =>  _mover.Stop();
        
        public void TakeDamage(float damage)
        {
            if (_health.CanRemove(damage))
                _health.Remove(damage);
        }

        public void Heal(float heal)
        {
            _health.Add(heal);
        }
    }
}