using _Game.Scripts.SpawnSystem;
using UnityEngine;

namespace _Game.Scripts.Auxiliary
{
    public class Input
    {
        private const KeyCode SwitchSpawnKeyCode = KeyCode.F;
        public Vector2 Position => UnityEngine.Input.mousePosition;

        public bool Button => UnityEngine.Input.GetMouseButton(0);
        public bool SwitcherSpawner => UnityEngine.Input.GetKeyDown(SwitchSpawnKeyCode);
    }
}