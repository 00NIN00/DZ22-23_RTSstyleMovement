using UnityEngine;

namespace _Game.Scripts.RotateSystem
{
    public interface IDirectionalRotatable
    {
        Quaternion CurrentRotation{get;}
        
        void SetRotateDirection(Vector3 inputDirection);
    }
}