using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
public class IArenaPlayer : MonoBehaviour, IArenaInterface
{
    private Rigidbody m_Rigidbody;
    private CapsuleCollider m_CapsuleCollider;
    private NavMeshAgent m_NavMeshAgent;

    [Range(1,100)]
    public int MaxHealth;
    private int m_CurrentHealth;

    private bool m_Blocking;

    [Range(0.1f,1f)]
    public float AttackDistance = 1.0f;

    [Range(1, 5)]
    public float JumpSpeed;

    [Range(1f,20f)]
    public float AttackDamage = 10.0f;

    [Range(0.1f,1f)]
    public float AttackCooldown = 0.5f; //[s]

    private bool m_IsAttacking = false;
    private float m_AttackTimer = 0.0f;

    private bool m_IsDead = false;

    void Awake()
    {
        m_CurrentHealth = MaxHealth;

        m_Rigidbody = GetComponent<Rigidbody>();
        m_CapsuleCollider = GetComponent<CapsuleCollider>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dead..
        if (m_IsDead)
            return;

        //attack cooldown
        if (m_IsAttacking)
        {
            m_AttackTimer += Time.deltaTime;
            if (m_AttackTimer >= AttackCooldown)
            {
                m_IsAttacking = false;
                m_AttackTimer = 0.0f;
            }
        }

    }

    /// <summary>
    /// Check if target is in range
    /// TODO: take AttackDistance from game mode.
    /// </summary>
    /// <param name="target"></param>
    void IArenaInterface.TakeDamage(IArenaInterface target)
    {
        Vector3 distance = transform.position - target.GetTransform().position;

        if (distance.magnitude <= AttackDistance)
        {
            if (m_Blocking)
                m_CurrentHealth -= Mathf.RoundToInt(AttackDamage / 2.0f);
            else
                m_CurrentHealth -= Mathf.RoundToInt(AttackDamage);
        }

        if (m_CurrentHealth <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        m_IsDead = true;
        m_NavMeshAgent.enabled = false;
    }

    public bool Block()
    {
        if (!m_IsAttacking)
            m_Blocking = true;
        return m_Blocking;
    }

    public bool UnBlock()
    {
        if (!m_IsAttacking)
            m_Blocking = false;
        return m_Blocking;
    }

    public bool Attack(IArenaInterface target)
    {
        if (!m_IsAttacking)
        {
            m_IsAttacking = true;
            target.TakeDamage(target);
            return true;
        }

        return false;
    }

    public bool MoveTo(Vector3 offset)
    {
        m_NavMeshAgent.Move(offset);
        return true;
    }

    public bool Jump()
    {
        m_Rigidbody.AddForce(Vector3.up * JumpSpeed);
        return false;
    }

    Transform IArenaInterface.GetTransform()
    {
        return transform;
    }
}
