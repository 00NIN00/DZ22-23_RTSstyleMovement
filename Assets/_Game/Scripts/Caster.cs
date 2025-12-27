using UnityEngine;

namespace _Game.Scripts
{
    public class Caster : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayerMask;
        
        private Input _input;
        private Character _character;

        public void Initialize(Input input, Character character)
        {
            _input = input;
            _character = character;
        }
        
        private Camera Camera => Camera.main;

        private void Update()
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
                    _character.SetPositionToMove(hit.point);
                }
            }
        }
    }
}