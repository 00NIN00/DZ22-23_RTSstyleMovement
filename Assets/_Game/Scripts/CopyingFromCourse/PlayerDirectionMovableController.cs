using _Game.Scripts.Controllers;
using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public class PlayerDirectionMovableController : Controller
    {
        private IDirectionalMovable _movable;

        public PlayerDirectionMovableController(IDirectionalMovable movable)
        {
            _movable = movable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 inputDirection = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));
            
            _movable.SetMoveDirection(inputDirection);
        }
    }
}