using UnityEngine;

namespace _Game.Scripts
{
    public class BootStrap : MonoBehaviour
    {
        [SerializeField] private Caster _caster;
        [SerializeField] private Character _character;

        private void Awake()
        {
            _caster.Initialize(new Input(), _character);
        }
    }
}