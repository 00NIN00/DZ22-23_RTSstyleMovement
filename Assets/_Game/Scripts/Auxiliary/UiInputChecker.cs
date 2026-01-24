using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Auxiliary
{
    public static class UiInputChecker
    {
        public static bool IsPointerOverUI()
        {
            // Мышь
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return true;

            // Тач
            if (EventSystem.current != null && UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    return true;
            }

            return false;
        }   
    }
}