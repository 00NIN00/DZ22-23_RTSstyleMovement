using UnityEngine;
using Input = _Game.Scripts.Auxiliary.Input;

namespace _Game.Scripts.SpawnSystem
{
    public class SpawnerHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _radius;
        [SerializeField] private float _timeBeetweenSpawn;
        
        private Spawner _spawner;
        private Input _input;

        public void Initialize(Spawner spawner, Input input)
        {
            _spawner = spawner;
            _input = input;
        }

        private void Update()
        {
            if (_input.SwitcherSpawner)
            {
                if (_spawner.IsProcess)
                    _spawner.StopSpawn();
                else
                    _spawner.TryStartSpawn(_timeBeetweenSpawn, _radius, _prefab);
            }
        }
    }
}