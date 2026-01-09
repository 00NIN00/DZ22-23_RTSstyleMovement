using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public class InputExample : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private Controller _characterController;

        private void Awake()
        {
            _characterController = new CompositeController(
                new PlayerDirectionMovableController(_character),
                new AlongMovableVelocityRotatableController(_character, _character));
            
            _characterController.Enable();
        }

        private void Update()
        {
            _characterController.Update(Time.deltaTime);
        }
    }
}