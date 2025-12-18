using UnityEngine.AI;
using UnityEngine;

namespace _Game.Scripts
{
    public class AgentMover : IMover
    {
        private readonly NavMeshAgent _agent;
        
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