using UnityEngine;

namespace _Game.Scripts
{
    public class Timer
    {
        private float _timer;
        
        private bool _isProcess;
        private bool _isOver;
        
        public bool TryStart(float timer)
        {
            if (_isProcess)
                return false;
            
            _timer = timer;
            _isProcess = true;
            
            return true;
        }

        public void Update()
        {
            if (_isProcess && _timer > 0)
                _timer -= Time.deltaTime;

            if (_timer <= 0 && _isProcess)
            {
                _isProcess = false;
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
            _isProcess = false;
            _isOver = false;
        }
    }
}