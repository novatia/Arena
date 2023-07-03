using MBT;
using UnityEngine;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("gabriel Moratelli/Researcher", 500)]
    public class GMTargetResearcher : Leaf
    {
        private GMArenaPlayer m_MyPlayer;

        private void Start()
        {
            m_MyPlayer = GetComponentInParent<GMArenaPlayer>();
        }

        public override NodeResult Execute()
        {
            CollectAllPlayers();
            if(FindActualTarget())
                return NodeResult.success;
            else
                return NodeResult.failure;
        }

        /// <summary>
        /// Collect every GameObject tagged as a player
        /// </summary>
        private void CollectAllPlayers()
        {
            GameObject[] otherPlayers = GameObject.FindGameObjectsWithTag("Target");
            m_MyPlayer.OthersPlayerList.Clear();

            foreach (GameObject player in otherPlayers)
            {
                m_MyPlayer.OthersPlayerList.Add(player);
            }
        }

        /// <summary>
        /// search in the list of player which is the nearest
        /// </summary>
        /// <returns></returns>
        private bool FindActualTarget()
        {
            float actualMinorDistance = 1000f;
            bool founded = false;
            foreach(GameObject player in m_MyPlayer.OthersPlayerList)
            {
                float distance = Vector3.Distance(m_MyPlayer.transform.position, player.transform.position);
                if(distance < actualMinorDistance)
                {
                    actualMinorDistance = distance;
                    m_MyPlayer.ActualTarget = player;
                    founded = true;
                }
            }
            return founded;
        }
    }
}
