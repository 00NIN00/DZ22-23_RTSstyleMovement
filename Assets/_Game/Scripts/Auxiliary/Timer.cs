using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Auxiliary
{
    public class Timer
    {
        private bool _isOver;
        public bool IsProcess => _coroutine != null;

        private Coroutine _coroutine;
        private readonly MonoBehaviour _monoBehaviour;

        public Timer(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }
        
        public bool TryStart(float timer)
        {
            if (IsProcess)
                return false;

            _coroutine = _monoBehaviour.StartCoroutine(TimerProcess(timer));

            return true;
        }

        private IEnumerator TimerProcess(float time)
        {
            yield return new WaitForSeconds(time);

            _coroutine = null;
            _isOver = true;
        }

        public bool IsOver()
        {
            if (_isOver)
            {
                _isOver = false;
                return true;
            }

            return false;
        }
    }
}