using _Game.Scripts.Controllers;
using _Game.Scripts.RotateSystem;

namespace _Game.Scripts.CopyingFromCourse
{
    public class AlongMovableVelocityRotatableController : Controller
    {
        private IDirectionalRotatable _rotatable;
        private IDirectionalMovable _movable;

        public AlongMovableVelocityRotatableController(IDirectionalRotatable rotatable, IDirectionalMovable movable)
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