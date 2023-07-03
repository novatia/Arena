namespace DenisFaraci.Nodes
{
    using MBT;
    using UnityEngine;
    using UnityEngine.AI;

    [MBTNode("DF/MoveToTarget")]
    [AddComponentMenu("")]
    public class MoveToTarget : Leaf
    {
        public NavMeshAgent agent;
        public TransformReference tranformTarget;

        public override NodeResult Execute()
        {
            Debug.Log("Trying to move to: " + tranformTarget.Value.name);
            agent.SetDestination(tranformTarget.Value.position);
            return NodeResult.success;
        }
    }
}