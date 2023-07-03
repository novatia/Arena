using MBT;
using UnityEngine;

namespace MBTExample
{
    namespace Nov41337
    {
        [AddComponentMenu("")]
        [MBTNode("Andrea Novati/Get Target", 500)]
        public class ANGetTargetNode : Leaf
        {

            IArenaPlayer m_Player =null;

            public override NodeResult Execute()
            {

                if (m_Player == null)
                    m_Player = GetComponentInParent<IArenaPlayer>();

                GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

                if (targets.Length <= 0)
                    return NodeResult.failure;

                GameObject nearest = targets[0];

                float distance = GetDistance(nearest);
                foreach (GameObject target in targets)
                {
                    if (GetDistance(nearest) < distance)
                    {
                        distance = GetDistance(nearest);
                        nearest = target;
                    }
                }


                return NodeResult.success;
            }

            float GetDistance(GameObject target)
            {
                return (target.transform.position - m_Player.gameObject.transform.position).magnitude;
            }
        }
    }
}