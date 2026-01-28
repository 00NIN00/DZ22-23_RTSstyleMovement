using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Controllers
{
    public class ControllerUpdater : MonoBehaviour
    {
        private readonly List<Controller> _controllers = new();

        public void AddEntity(params Controller[] controllers)
        {
            CompositeController compositeController = new(controllers);
            
            compositeController.Enable();
            _controllers.Add(compositeController);
        }
        
        private void Update()
        {
            foreach (Controller controller in _controllers)
            {
                controller.Update(Time.deltaTime);
            }
        }
    }
}