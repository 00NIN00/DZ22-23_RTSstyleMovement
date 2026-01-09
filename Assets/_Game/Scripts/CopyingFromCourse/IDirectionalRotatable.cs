using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public interface IDirectionalRotatable
    {
        Quaternion CurrentRotation{get;}
        
        void SetRotateDirection(Vector3 inputDirection);
    }
}