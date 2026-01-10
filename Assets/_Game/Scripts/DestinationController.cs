using _Game.Scripts.CopyingFromCourse;
using UnityEngine;

namespace _Game.Scripts
{
    public class DestinationController : Controller
    {
        private LayerMask _groundLayerMask;
        
        private Input _input;
        private AgentCharacter _character;

        public DestinationController(Input input,  AgentCharacter character, LayerMask groundLayerMask)
        {
            _input = input;
            _character = character;
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
                    _character.SetDestination(hit.point);
                }
            }
        }
    }
}