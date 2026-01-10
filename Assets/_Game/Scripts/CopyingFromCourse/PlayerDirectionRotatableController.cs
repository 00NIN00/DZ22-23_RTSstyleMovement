using _Game.Scripts.Controllers;
using _Game.Scripts.RotateSystem;
using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public class PlayerDirectionRotatableController : Controller
    {
        private IDirectionalRotatable _rotatable;

        public PlayerDirectionRotatableController(IDirectionalRotatable rotatable)
        {
            _rotatable = rotatable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 inputDirection = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));
            
            _rotatable.SetRotateDirection(inputDirection);    
        }
    }
}