using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable
    {
        private DirectionalMover _mover;
        private DirectionRotator _rotator;
        
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _moveRotate;
        
        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;

        private void Awake()
        {
            _mover = new DirectionalMover(GetComponent<CharacterController>(), _moveSpeed);
            _rotator = new DirectionRotator(transform, _moveRotate);
        }

        private void Update()
        {
            _mover.Update(Time.deltaTime);
            _rotator.Update(Time.deltaTime);
        }
        
        public void SetMoveDirection(Vector3 inputDirection) => _mover.SetDirection(inputDirection);
        public void SetRotateDirection(Vector3 inputDirection) => _rotator.SetDirection(inputDirection);
    }
}