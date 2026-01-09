using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public interface IDirectionalMovable
    {
        Vector3 CurrentVelocity {get;}
        
        void SetMoveDirection(Vector3 inputDirection);
    }
}