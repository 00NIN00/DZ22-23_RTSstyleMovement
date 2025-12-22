using UnityEngine;

namespace _Game.Scripts
{
    public class ViewTargetPointCharacter : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Flag _flag;
        
        private void Update()
        {
            if (_character.Position != _flag.transform.position)
            {
                if (!_flag.gameObject.activeSelf)
                    _flag.gameObject.SetActive(true);
                
                _flag.transform.position= _character.Position;
            }
            
            if (_character.IsFinishing)
            {
                _flag.gameObject.SetActive(false);
            }
        }
    }
}