using UnityEngine;

namespace _Game.Scripts
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private Caster _caster;
        [SerializeField] private Character _character;
        [SerializeField] private Transform _flagTransform;

        private void Awake()
        {
            _caster.Initialize(new Input(), _character, _flagTransform);
        }
    }
}