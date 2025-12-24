using UnityEngine.AI;
using UnityEngine;

namespace _Game.Scripts
{
    public class AgentMover : IMover, IAnimatorMove
    {
        private readonly NavMeshAgent _agent;
        public bool IsFinishing =>  !_agent.pathPending && !_agent.hasPath && _agent.remainingDistance <= _agent.stoppingDistance;
        public float Speed => _agent.velocity.magnitude / _agent.speed;
        public AgentMover(NavMeshAgent agent)
        {
            _agent = agent;
        }
        
        public void Move(Vector3 position)
        {
            _agent.SetDestination(position);
        }
    }
}