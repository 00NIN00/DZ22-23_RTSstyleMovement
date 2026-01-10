using _Game.Scripts.CopyingFromCourse;
using UnityEngine;

namespace _Game.Scripts
{
    public class DestinationController : Controller
    {
        private LayerMask _groundLayerMask;
        
        private Input _input;
        private IDestinationMovable _destinationMovable;

        public DestinationController(Input input,  AgentCharacter destinationMovable, LayerMask groundLayerMask)
        {
            _input = input;
            _destinationMovable = destinationMovable;
            _groundLayerMask = groundLayerMask;
        }
        
        private Camera Camera => Camera.main;
        
        protected override void UpdateLogic(float deltaTime)
        {
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