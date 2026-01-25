using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace _Game.Scripts.MoveSystem
{
    public class AgentJumper
    {
        private readonly MonoBehaviour _coroutineRunner;
        
        private float _speedJump;
        private NavMeshAgent _agent;
        
        private Coroutine _coroutine;
        public AgentJumper(MonoBehaviour coroutineRunner, float speedJump, NavMeshAgent agent)
        {
            _speedJump = speedJump;
            _agent = agent;
            _coroutineRunner = coroutineRunner;
        }
        
        public bool InProcess => _coroutine != null;

        public void Jump(OffMeshLinkData offMeshLinkData)
        {
            if(InProcess)
                return;
            
            _coroutine = _coroutineRunner.StartCoroutine(JumpProcess(offMeshLinkData));
        }

        private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData)
        {
            Vector3 startPosition = offMeshLinkData.startPos;
            Vector3 endPosition = offMeshLinkData.endPos;
            
            float duration = Vector3.Distance(startPosition, endPosition) /  _speedJump;

            float progress = 0;

            while (progress < duration)
            {
                _agent.transform.position = Vector3.Lerp(startPosition, endPosition, progress / duration);
                progress += Time.deltaTime;
                yield return null;
            }
            
            _agent.CompleteOffMeshLink();
            _coroutine = null;
        }
    }
}