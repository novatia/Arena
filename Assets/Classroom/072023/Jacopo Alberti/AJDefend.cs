using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Jacopo Alberti/Defend", 500)]
public class AJDefend : Leaf
{
    private AJPlayer m_Player;

    private void OnEnable()
    {
        m_Player = GetComponentInParent<AJPlayer>();
    }

    public void Defend()
    {
        m_Player.Enemy.TryGetComponent(out IArenaPlayer enem);
        if (enem.Attack(m_Player))
        {
            m_Player.Block();
        }
    }
    public override NodeResult Execute()
    {
        if (m_Player.Block())
        {
            return NodeResult.success;
        }
        else
        {
            return NodeResult.failure;
        }
    }
    
}
