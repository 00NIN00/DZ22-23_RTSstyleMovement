using _Game.Scripts.MoveSystem;
using _Game.Scripts.View;
using UnityEngine;

namespace _Game.Scripts.Entity
{
    public class Character : MonoBehaviour, IMineTriggerable
    {
        private IMover _mover;
        private Vector3 _targetMovePosition;
        private bool _isChangePosition = false;
        
        private HealthSystem.HealthViewSystem _healthViewSystem;
        
        public Vector3 TargetMovePosition => _targetMovePosition;
        public bool IsFinishing => _mover.IsFinishing;
        public IMoveView MoveView {get ; private set;}

        public void Initialize(IMover mover, IMoveView moveView, HealthSystem.HealthViewSystem healthViewSystem)
        {
            _mover = mover;
            MoveView = moveView;
            _healthViewSystem = healthViewSystem;
        }
        
        public void SetPositionToMove(Vector3 position)
        {
            _targetMovePosition = position;
            _isChangePosition = true;
        }
        
        private void Update()
        {
            if (_healthViewSystem.IsAlive == false)
            {
                _mover.StopMoving();
                return;
            }
            
            if (_isChangePosition)
            {
                _isChangePosition = false;
                _mover.Move(_targetMovePosition);
            }
        }
    }
}
