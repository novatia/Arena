using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;

[AddComponentMenu("")]
[MBTNode("Jacopo Alberti/Search Enemies", 500)]
public class AJSearchEnemies : Leaf
{
    private AJPlayer m_Player;

    private void OnEnable()
    {
        m_Player = GetComponentInParent<AJPlayer>();
    }

    public Vector3 SearchPlayer()
    {
        m_Player.Enemy = GameObject.FindGameObjectWithTag("Target");
        return m_Player.Enemy.transform.position;
    }
    public override NodeResult Execute()
    {
        if (m_Player.Enemy != null)
        {
            return NodeResult.success;
        }
        else
        {
            return NodeResult.failure;
        }
    }

}
