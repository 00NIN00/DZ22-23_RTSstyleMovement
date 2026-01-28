using UnityEngine;

namespace _Game.Scripts.Auxiliary
{
    public class Destroyer : MonoBehaviour
    {
        public void Initialize(float time)
        {
            Destroy(gameObject, time);
        }
    }
}