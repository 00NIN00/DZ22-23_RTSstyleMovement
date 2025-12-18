using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts
{
    public class Character : MonoBehaviour
    {
        private IMover _mover;
        private Vector3 _position;

        private void Awake()
        {
            _mover = new AgentMover(GetComponent<NavMeshAgent>());
        }

        public void SetPositionToMove(Vector3 position)
        {
            _position = position;
        }
        
        private void Update()
        {
            _mover.Move(_position);
        }
    }
}
