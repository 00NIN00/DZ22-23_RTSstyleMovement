using UnityEngine.AI;

namespace _Game.Scripts.MoveSystem
{
    public interface IDestinationJumped
    {
        public bool InJumpProcess { get; }
        public bool IsOnMavMeshLink(out OffMeshLinkData offMeshLinkData);
        public void Jump(OffMeshLinkData offMeshLinkData);
    }
}