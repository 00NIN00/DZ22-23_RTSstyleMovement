using _Game.Scripts.HealthSystem;
using _Game.Scripts.MoveSystem;
using _Game.Scripts.View;
using UnityEngine;

namespace _Game.Scripts.Entity
{
    public class Character : MonoBehaviour, IMineTriggerable, IDamageable
    {
        private IMover _mover;
        private Vector3 _targetMovePosition;
        private bool _isChangePosition = false;
        
        private Health _health;
        
        public IMoveView MoveView {get ; private set;}
        public Vector3 TargetMovePosition => _targetMovePosition;
        public bool IsFinishing => _mover.IsFinishing;

        public void Initialize(IMover mover, IMoveView moveView, Health health)
        {
            _mover = mover;
            MoveView = moveView;
            _health = health;
        }
        
        public void SetPositionToMove(Vector3 position)
        {
            _targetMovePosition = position;
            _isChangePosition = true;
        }
        
        private void Update()
        {
            if (_health.IsAlive == false)
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

        public void TakeDamage(float damage)
        {
            if (_health.CanRemove(damage))
                _health.Remove(damage);
        }
    }
}
