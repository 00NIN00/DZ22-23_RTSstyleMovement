using _Game.Scripts.Auxiliary;
using _Game.Scripts.Entity;
using _Game.Scripts.MoveSystem;
using _Game.Scripts.RotateSystem;
using UnityEngine;
using UnityEngine.AI;
using Input = _Game.Scripts.Auxiliary.Input;

namespace _Game.Scripts.Controllers
{
    public class DestinationController : Controller
    {
        private LayerMask _groundLayerMask;

        private Input _input;
        private IDestinationMovable _destinationMovable;
        private IDestinationJumped _destinationJumped;
        private IDirectionalRotatable _rotator;

        public DestinationController(Input input,  IDestinationMovable destinationMovable, LayerMask groundLayerMask, IDestinationJumped destinationJumped, IDirectionalRotatable rotator)
        {
            _input = input;
            _destinationMovable = destinationMovable;
            _groundLayerMask = groundLayerMask;
            _destinationJumped = destinationJumped;
            _rotator = rotator;
        }
        
        private Camera Camera => Camera.main;
        
        protected override void UpdateLogic(float deltaTime)
        {
            if (_input.IsPointerOverUI())
            {
                return;
            }

            if (_destinationJumped.IsOnMavMeshLink(out OffMeshLinkData offMeshLinkData))
            {
                if (_destinationJumped.InJumpProcess == false)
                {
                    _rotator.SetRotateDirection(offMeshLinkData.endPos - offMeshLinkData.startPos);
                    
                    _destinationJumped.Jump(offMeshLinkData);
                }
                
                return;
            }
            
            _rotator.SetRotateDirection(_destinationMovable.CurrentVelocity);
            
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