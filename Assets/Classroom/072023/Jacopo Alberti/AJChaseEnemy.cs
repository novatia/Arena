using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Jacopo Alberti/Chase Enemy", 500)]
public class AJChaseEnemy : Leaf
{
    private AJPlayer m_Player;

    private void OnEnable()
    {
        m_Player = GetComponentInParent<AJPlayer>();
    }

    public void ChaseEnemy()
    {
        m_Player.MoveTo(m_Player.Enemy.transform.position - transform.position);
    }

    public override NodeResult Execute()
    {
        if (Vector3.Distance(m_Player.Enemy.transform.position, m_Player.transform.position) <= 1f)
        {
            return NodeResult.success;
        }
        else
        {
            return NodeResult.running;
        }
    }
}
