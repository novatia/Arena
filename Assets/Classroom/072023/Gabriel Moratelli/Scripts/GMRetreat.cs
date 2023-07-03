using MBT;
using UnityEngine;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("gabriel Moratelli/Retreat", 500)]
    public class GMRetreat : Leaf
    {
        private GMArenaPlayer m_MyPlayer;

        private void Start()
        {
            m_MyPlayer = GetComponentInParent<GMArenaPlayer>();
        }

        public override NodeResult Execute()
        {
            m_MyPlayer.Destination(CreateRetreatPoint());
            return NodeResult.success;
        }

        private Vector3 CreateRetreatPoint()
        {
            Vector3 pos = -m_MyPlayer.transform.forward * 5;
            return pos;
        }
    }
}
