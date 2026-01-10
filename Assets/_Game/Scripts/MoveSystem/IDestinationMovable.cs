using UnityEngine;

namespace _Game.Scripts.MoveSystem
{
    public interface IDestinationMovable
    {
        Vector3 CurrentVelocity { get; }
        void SetDestination(Vector3 position);
    }
}