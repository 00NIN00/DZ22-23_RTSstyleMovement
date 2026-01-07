namespace _Game.Scripts.View
{
    public interface IAnimatorHealth
    {
        public float Health { get; }
        public float MaxHealth { get; }
        bool IsAlive { get; }
        bool TakeDamageEvent();
    }
}