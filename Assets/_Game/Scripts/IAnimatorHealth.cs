namespace _Game.Scripts
{
    public interface IAnimatorHealth
    {
        public float Health { get; }
        public float MaxHealth { get; }
        bool IsAlive { get; }
        bool TakeDamageEvent();
    }
}