using UnityEngine.AI;
using UnityEngine;

namespace _Game.Scripts
{
    public class Character : MonoBehaviour, IMineTriggerable
    {
        private IMover _mover;
        private Vector3 _position;
        
        private bool _isChangePosition = false;

        public Vector3 Position => _position;
        public bool IsFinishing => _mover.IsFinishing;
        
        public IAnimatorMove AnimatorMove {get ; private set;}

        public void Initialize(IMover mover, IAnimatorMove animatorMove)
        {
            _mover = mover;
            AnimatorMove = animatorMove;
        }
        
        public void SetPositionToMove(Vector3 position)
        {
            _position = position;
            _isChangePosition = true;
        }
        
        private void Update()
        {
            if (_isChangePosition)
            {
                _isChangePosition = false;
                _mover.Move(_position);
            }
        }
    }
}
