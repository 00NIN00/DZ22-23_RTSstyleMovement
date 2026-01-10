using UnityEngine;

namespace _Game.Scripts.RotateSystem
{
    public interface IDestinationMovable
    {
        Vector3 CurrentVelocity { get; }
        void SetDestination(Vector3 position);
    }
}