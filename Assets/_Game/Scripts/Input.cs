using UnityEngine;

namespace _Game.Scripts
{
    public class Input
    {
        public Vector2 Position => UnityEngine.Input.mousePosition;

        public bool Button => UnityEngine.Input.GetMouseButton(0);
    }
}