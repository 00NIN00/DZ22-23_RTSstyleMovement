namespace _Game.Scripts.View
{
    public interface IHealthForView
    {
        public float Value { get; }
        public float MaxValue { get; }
        bool IsAlive { get; }
        bool TakeDamageEvent();
    }
}