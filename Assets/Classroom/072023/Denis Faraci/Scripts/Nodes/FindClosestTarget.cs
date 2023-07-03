namespace DenisFaraci.Nodes
{
    using UnityEngine;
    using MBT;
    using MBTExample;
    using VUDK.Extensions.Finders;
    using DenisFaraci.Interfaces;

    [MBTNode("DF/FindClosestTarget")]
    [AddComponentMenu("")]
    public class FindClosestTarget : Leaf
    {
        public TransformReference transformTarget;
        public float maxDistance;

        public override NodeResult Execute()
        {
            if (gameObject.TryGetClosestGameObjectWithTag("Target", out GameObject closest)
                && Vector3.Distance(transform.position, closest.transform.position) <= maxDistance)
            {
                transformTarget.Value = closest.transform;
                return NodeResult.success;
            }

            Debug.Log("Failed");
            return NodeResult.failure;
        }
    }
}
