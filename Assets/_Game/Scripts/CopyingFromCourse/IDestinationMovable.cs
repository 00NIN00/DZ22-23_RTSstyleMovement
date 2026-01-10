using UnityEngine;

namespace _Game.Scripts.CopyingFromCourse
{
    public interface IDestinationMovable
    {
        Vector3 CurrentVelocity { get; }
        void SetDestination(Vector3 position);
    }
}