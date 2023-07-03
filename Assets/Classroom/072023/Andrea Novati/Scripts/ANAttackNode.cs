using MBT;
using UnityEngine;

namespace MBTExample
{
    namespace Nov41337
    {
        [AddComponentMenu("")]
        [MBTNode("Andrea Novati/Attack", 500)]
        public class ANAttackNode : Leaf
        {
            IArenaPlayer m_ArenaPlayer;

            IArenaInterface m_Proxy;
            ANPlayer m_Player = null;

            public override NodeResult Execute()
            {
                if (m_Player == null)
                    m_Player = GetComponentInParent<ANPlayer>();

                if (m_ArenaPlayer == null)
                {
                    m_ArenaPlayer = GetComponentInParent<IArenaPlayer>();
                    m_Proxy = (IArenaInterface)m_ArenaPlayer;
                }
                
                Debug.Log("NOV41337 ATTACK "+ m_Player.Target.name);
                m_Proxy.Attack((IArenaInterface)m_Player.Target.GetComponent<IArenaPlayer>());
                return NodeResult.success;
            }
        }
    }
}