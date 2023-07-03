using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

namespace MBT
{
    [AddComponentMenu("")]
    [MBTNode(name = "Michele Grassano/Move Random Node", order = 1)]
    public class MG_MoveRandomNode : Leaf
    {
        [SerializeField]
        private float moveRadius = 5f;

        private NavMeshAgent agent;
        private bool isMoving = false;

        public override void OnEnter()
        {
            agent = GetComponent<NavMeshAgent>();
            MoveRandom();
        }

        public override NodeResult Execute()
        {
            if (!isMoving)
            {
                MoveRandom();
            }
            else
            {
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    isMoving = false;
                    return NodeResult.success;
                }
                return NodeResult.running;
            }

            return NodeResult.success;
        }

        private void MoveRandom()
        {
            Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, moveRadius, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
            isMoving = true;
        }
    }
}
