namespace _Game.Scripts.CopyingFromCourse
{
    public class AlongMovableDestinationRotatableController : Controller
    {
        private IDirectionalRotatable _rotatable;
        private AgentCharacter _movable;

        public AlongMovableDestinationRotatableController(IDirectionalRotatable rotatable, AgentCharacter movable)
        {
            _rotatable = rotatable;
            _movable = movable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _rotatable.SetRotateDirection(_movable.CurrentVelocity);
        }
    }
}