using MBT;
using UnityEngine;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("gabriel Moratelli/Cutter", 500)]
    public class GMCutter : Leaf
    {
        private GMArenaPlayer m_MyPlayer;

        private void Start()
        {
            m_MyPlayer = GetComponentInParent<GMArenaPlayer>();
        }

        public override NodeResult Execute()
        {
            if(m_MyPlayer.Attack(m_MyPlayer.ActualTarget.GetComponent<IArenaInterface>()))
                return NodeResult.success;
            else
                return NodeResult.failure;
        }
    }
}
