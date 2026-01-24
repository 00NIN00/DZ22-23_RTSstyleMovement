using _Game.Scripts.Auxiliary;
using _Game.Scripts.CopyingFromCourse;
using _Game.Scripts.Entity;
using _Game.Scripts.MoveSystem;
using _Game.Scripts.RotateSystem;
using UnityEngine;
using Input = _Game.Scripts.Auxiliary.Input;

namespace _Game.Scripts.Controllers
{
    public class DestinationController : Controller
    {
        private LayerMask _groundLayerMask;
        
        private Input _input;
        private IDestinationMovable _destinationMovable;

        public DestinationController(Input input,  IDestinationMovable destinationMovable, LayerMask groundLayerMask)
        {
            _input = input;
            _destinationMovable = destinationMovable;
            _groundLayerMask = groundLayerMask;
        }
        
        private Camera Camera => Camera.main;
        
        protected override void UpdateLogic(float deltaTime)
        {
            if (UiInputChecker.IsPointerOverUI())
            {
                return;
            }
            
            if (_input.Button)
                Cast(_input.Position);
        }
        
        private void Cast(Vector2 position)
        {
            Ray ray = Camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayerMask))
            {
                if (hit.collider != null)
                {
                    _destinationMovable.SetDestination(hit.point);
                }
            }
        }
    }
}