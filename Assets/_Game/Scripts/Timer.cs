using UnityEngine;

namespace _Game.Scripts
{
    public class Timer
    {
        private float _timer;
        
        private bool _isOver;
        public bool IsProcess { get; private set; }
        
        public bool TryStart(float timer)
        {
            if (IsProcess)
                return false;
            
            _timer = timer;
            IsProcess = true;
            
            return true;
        }

        public void Update()
        {
            if (IsProcess && _timer > 0)
                _timer -= Time.deltaTime;

            if (_timer <= 0 && IsProcess)
            {
                IsProcess = false;
                _isOver = true;;
            }
        }

        public bool IsOver()
        {
            if (_isOver)
            {
                Reset();
                return true;
            }

            return false;
        }

        private void Reset()
        {
            IsProcess = false;
            _isOver = false;
        }
    }
}