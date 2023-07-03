using UnityEngine;
using MBT;
using System.Collections.Generic;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("Grasso Lorenzo/MoveToTheEnemy")]
    public class MoveTowards : Leaf
    {
        bool isChasing;
        LGIArenaPlayer m_Player;

        private void Start()
        {
            m_Player = GetComponentInParent<LGIArenaPlayer>();
        }

        public override NodeResult Execute()
        {
            if(m_Player.Enemies.Count==0) return NodeResult.failure;

            m_Player.Enemies.Reverse();

            isChasing =  m_Player.Destination(m_Player.Enemies[0].transform.position);

            if (!isChasing) return NodeResult.running;
            else return NodeResult.success;
           
        }
        
    }
}
