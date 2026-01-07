using _Game.Scripts.Entity;
using UnityEngine;

namespace _Game.Scripts.View
{
    public class ViewTargetPointCharacter : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Flag _flag;
        
        private void Update()
        {
            if (_character.TargetMovePosition != _flag.transform.position)
            {
                if (!_flag.gameObject.activeSelf)
                    _flag.gameObject.SetActive(true);
                
                _flag.transform.position= _character.TargetMovePosition;
            }
            
            if (_character.IsFinishing)
            {
                _flag.gameObject.SetActive(false);
            }
        }
    }
}