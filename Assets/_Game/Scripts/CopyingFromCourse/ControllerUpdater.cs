using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public class ControllerUpdater : MonoBehaviour
    {
        private Controller _characterController;

        public void Initialize(Controller moveController, Controller rotateController)
        {
            _characterController = new CompositeController(moveController, rotateController);
            
            _characterController.Enable();
        }
        
        private void Update()
        {
            _characterController.Update(Time.deltaTime);
        }
    }
}