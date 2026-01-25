using _Game.Scripts.Auxiliary;
using _Game.Scripts.HealthSystem;
using _Game.Scripts.MoveSystem;
using _Game.Scripts.RotateSystem;
using UnityEngine.AI;
using UnityEngine;

namespace _Game.Scripts.Entity
{
    public class AgentCharacter : MonoBehaviour, IMineTriggerable, IDamageable, IDirectionalRotatable,
        IDestinationMovable, IDestinationJumped,  IHealable
    {
        private NavMeshAgent _agent;

        private AgentMover _mover;
        private DirectionRotator _rotator;
        private AgentJumper _jumper;

        private float _moveSpeed;
        private float _rotateSpeed;
        private float _jumpSpeed;

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;

        public Vector3 TargetMovePosition => _agent.destination;

        public bool IsFinishing =>
            !_agent.pathPending && !_agent.hasPath && _agent.remainingDistance <= _agent.stoppingDistance;

        private Health _health;

        public bool InJumpProcess => _jumper.InProcess;
        
        public void Initialize(Health health, NavMeshAgent agent, float moveSpeed, float rotateSpeed, float jumpSpeed)
        {
            _health = health;
            _agent = agent;

            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;
            _jumpSpeed = jumpSpeed;

            _agent.updateRotation = false;

            _mover = new AgentMover(_agent, _moveSpeed);
            _rotator = new DirectionRotator(_agent.transform, _rotateSpeed);
            _jumper = new AgentJumper(this, _jumpSpeed, _agent);
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

        public void ResumeMoving() => _mover.Resume();
        public void StopMoving() => _mover.Stop();

        public bool IsOnMavMeshLink(out OffMeshLinkData offMeshLinkData)
        {
            if (_agent.isOnOffMeshLink)
            {
                offMeshLinkData = _agent.currentOffMeshLinkData;
                return true;
            }
            
            offMeshLinkData = default(OffMeshLinkData);
            return false;
        }

        public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData);

        public void TakeDamage(float damage)
        {
            if (_health.CanRemove(damage))
                _health.Remove(damage);
        }

        public void Heal(float heal) => _health.Add(heal);
    }

    public interface IDestinationJumped
    {
        public bool InJumpProcess { get; }
        public bool IsOnMavMeshLink(out OffMeshLinkData offMeshLinkData);
        public void Jump(OffMeshLinkData offMeshLinkData);
    }
}