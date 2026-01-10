using _Game.Scripts.CopyingFromCourse;
using _Game.Scripts.Entity;
using _Game.Scripts.RotateSystem;

namespace _Game.Scripts.Controllers
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