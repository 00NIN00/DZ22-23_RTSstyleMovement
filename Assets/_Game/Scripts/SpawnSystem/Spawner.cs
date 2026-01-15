using System.Collections;
using UnityEngine;

namespace _Game.Scripts.SpawnSystem
{
    public class Spawner
    {
        private const float PositionSpawnY = 1;
     
        private Coroutine _coroutine;
        private Transform _spawnTransform;
        private MonoBehaviour _monoBehaviour;
        
        private GameObject _prefab;
        private float _radius;
        

        public bool IsProcess => _coroutine != null;
        
        public Spawner(Transform spawnTransform, MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
            _spawnTransform = spawnTransform;
        }

        public bool TryStartSpawn(float timeBeetWeenSpawn, float radius, GameObject prefab)
        {
            if (_coroutine != null)
                return false;

            _radius = radius;
            _prefab = prefab;
            
            _monoBehaviour.StartCoroutine(Process(timeBeetWeenSpawn));
            
            return true;
        }

        public void StopSpawn()
        {
            if (_coroutine != null)
                _monoBehaviour.StopCoroutine(_coroutine);
        }

        private IEnumerator Process(float timeBeetWeenSpawn)
        {
            while (true)
            {
                yield return new WaitForSeconds(timeBeetWeenSpawn);
                Spawn();
            }
        }

        private void Spawn()
        {
            Object.Instantiate(_prefab, GetPosition(_radius, _spawnTransform.position), Quaternion.identity);
        }


        private Vector3 GetPosition(float radius, Vector3 center)
        {
            Vector3 randomOffset = Random.insideUnitSphere * radius;
            Debug.Log(center);
            return center + new Vector3(randomOffset.x, PositionSpawnY, randomOffset.z);
        }
    }
}