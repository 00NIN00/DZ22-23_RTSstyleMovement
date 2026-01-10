using _Game.Scripts.MoveSystem;
using _Game.Scripts.RotateSystem;

namespace _Game.Scripts.Controllers
{
    public class AlongMovableDestinationRotatableController : Controller
    {
        private IDirectionalRotatable _rotatable;
        private IDestinationMovable _movable;

        public AlongMovableDestinationRotatableController(IDirectionalRotatable rotatable, IDestinationMovable movable)
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