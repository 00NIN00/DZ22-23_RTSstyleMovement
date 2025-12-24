using UnityEngine;

namespace _Game.Scripts
{
    public interface IMover
    {
        bool IsFinishing { get; }

        void Move(Vector3 position);
    }
}