using UnityEngine;

namespace _Game.Scripts.MoveSystem
{
    public interface IMover
    {
        bool IsFinishing { get; }

        void Move(Vector3 position);
        
        void StopMoving();
    }
}