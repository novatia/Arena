using MBT;
using UnityEngine;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("gabriel Moratelli/Chaser", 500)]
    public class GMChasingTarget : Leaf
    {
        private GMArenaPlayer m_MyPlayer;

        private void Start()
        {
            m_MyPlayer = GetComponentInParent<GMArenaPlayer>();
        }

        public override NodeResult Execute()
        {
            if(!CheckDistanceFromTarget())
                return NodeResult.running;
            else
                return NodeResult.success;
        }

        private bool CheckDistanceFromTarget()
        {
            float distance = Vector3.Distance(m_MyPlayer.transform.position, m_MyPlayer.ActualTarget.transform.position);
            bool isNear;
            if (distance > 1)
            {
                m_MyPlayer.Destination(m_MyPlayer.ActualTarget.transform.position);
                m_MyPlayer.IsTargetNear = false;
                return m_MyPlayer.IsTargetNear;
            }
            else
            {
                m_MyPlayer.Destination(m_MyPlayer.transform.position);
                m_MyPlayer.IsTargetNear = true;
                return m_MyPlayer.IsTargetNear;
            }
        }
    }
}
