using UnityEngine;

namespace _Game.Scripts
{
    public class Caster : MonoBehaviour
    {
        private Input _input;
        private Character _character;
        private Transform _flagTransform;
        
        public void Initialize(Input input, Character character, Transform flagTransform)
        {
            _input = input;
            _character = character;
            _flagTransform = flagTransform;
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

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    _character.SetPositionToMove(hit.point);
                    _flagTransform.position = hit.point;
                }
            }
        }
    }
}