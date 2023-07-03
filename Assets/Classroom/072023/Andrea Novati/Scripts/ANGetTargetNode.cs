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

            ANPlayer m_Player = null;
            public override NodeResult Execute()
            {

                if (m_Player == null)
                    m_Player = GetComponentInParent<ANPlayer>();
                if (m_Player.Target != null)
                    if (!m_Player.TargetIsDead())
                        return NodeResult.success;


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

                if (nearest != null)
                {
                    
                    m_Player.SetTarget(nearest);
                    return NodeResult.success;
                }


                return NodeResult.failure;
            }

            float GetDistance(GameObject target)
            {
                return (target.transform.position - m_Player.gameObject.transform.position).magnitude;
            }
        }
    }
}