using UnityEngine;

namespace _Game.Scripts
{
    public class AnimatorScale
    {
        private readonly Vector3 _baseScale;
        private readonly float _speed;
        private readonly float _amplitude;
        
        private Transform _transform;
        public AnimatorScale(Vector3 baseScale, Transform transform, float speed = 6f,  float amplitude = 0.6f)
        {
            _baseScale = baseScale;
            _transform = transform;
            _speed = speed;
            _amplitude = amplitude;
        }

        public void Update(float deltaTime)
        {
            float scaleFactor = 1f + Mathf.Sin(deltaTime * _speed) * _amplitude;
            
            _transform.localScale = new Vector3(
                _baseScale.x * scaleFactor,
                _baseScale.y * scaleFactor,
                _baseScale.z * scaleFactor);
        }
    }
}