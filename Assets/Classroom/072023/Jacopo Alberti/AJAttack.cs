using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Jacopo Alberti/Attack", 500)]
public class AJAttack : Leaf
{
    private AJPlayer m_Player;

    private void OnEnable()
    {
        m_Player = GetComponentInParent<AJPlayer>();
    }

    private void Attacking()
    {
        if (m_Player.Block())
        {
            m_Player.UnBlock();
        }
        m_Player.Attack(m_Player.Enemy.GetComponent<IArenaInterface>());
    }

    public override NodeResult Execute()
    {
        if (m_Player.Enemy.GetComponent<IArenaInterface>() != null)
        {
            return NodeResult.success;
        }
        else
        {
            return NodeResult.failure;
        }
    }

}