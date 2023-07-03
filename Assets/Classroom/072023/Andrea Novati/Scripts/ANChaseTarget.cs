using MBT;
using UnityEngine;

namespace MBTExample
{
    namespace Nov41337
    {
        [AddComponentMenu("")]
        [MBTNode("Andrea Novati/Chase Target", 500)]
        public class ANChaseTarget: Leaf
        {
            IArenaPlayer m_ArenaPlayer;
            IArenaInterface m_Proxy;
            ANPlayer m_Player = null;
            public override NodeResult Execute()
            {

                if (m_Player == null)
                    m_Player = GetComponentInParent<ANPlayer>();

                if (m_ArenaPlayer == null) {
                    m_ArenaPlayer = GetComponentInParent<IArenaPlayer>();
                    m_Proxy = (IArenaInterface)m_ArenaPlayer; 
                }

                if (m_Player.Target == null)
                    return NodeResult.failure;

                m_Proxy.Destination(m_Player.Target.transform.position);

                if (GetDistance (m_Player.Target) > (m_ArenaPlayer.AttackDistance-0.05f))
                {
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