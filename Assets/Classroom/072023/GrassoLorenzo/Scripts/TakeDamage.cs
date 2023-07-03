using UnityEngine;
using MBT;
using System.Collections.Generic;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("Grasso Lorenzo/TakeDamage")]
    public class TakeDamage : Leaf
    {
        LGIArenaPlayer m_Player;

        private void Start()
        {
            m_Player = GetComponentInParent<LGIArenaPlayer>();
        }

        public override NodeResult Execute()
        {
            IArenaPlayer enemies;
            enemies = m_Player.Enemies[0].GetComponent<IArenaPlayer>();
            if (enemies.Health <= 0) return NodeResult.success;
            else
            {
                m_Player.Attack(m_Player.Enemies[0].GetComponent<IArenaInterface>());
                return NodeResult.running;
            }
        }
  
    }
}
