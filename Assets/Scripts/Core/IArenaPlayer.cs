using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(TextMesh))]
public class IArenaPlayer : MonoBehaviour, IArenaInterface
{
    private Rigidbody m_Rigidbody;
    private CapsuleCollider m_CapsuleCollider;
    private NavMeshAgent m_NavMeshAgent;

    [Range(1,100)]
    public int MaxHealth=100;
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

    public Transform HealthBar;
    public Transform PlayerName;
    private TMP_Text m_TextMesh;


    protected void Awake()
    {
        m_CurrentHealth = MaxHealth;

        m_Rigidbody = GetComponent<Rigidbody>();
        m_CapsuleCollider = GetComponent<CapsuleCollider>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_TextMesh = PlayerName.GetComponent<TMP_Text>();

        SetName("Fool");
    }

    // Update is called once per frame
    protected void Update()
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

        UpdateHealthbarRotation();
        UpdatePlayerName();
    }

    private void UpdateHealthbar() 
    {
        Vector3 local_scale = HealthBar.localScale;
        local_scale.x = local_scale.x * m_CurrentHealth / MaxHealth;
        HealthBar.localScale = local_scale;
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
            m_CurrentHealth = 0;
        }

        UpdateHealthbar();
    }

    private void UpdateHealthbarRotation()
    {
        HealthBar.transform.LookAt(Camera.main.transform);
    }

    private void UpdatePlayerName()
    {
        PlayerName.transform.LookAt(Camera.main.transform);
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

    public bool Unblock()
    {
        if (!m_IsAttacking)
            m_Blocking = false;
        return m_Blocking;
    }

    public bool Attack(IArenaInterface target)
    {
        if (!m_IsAttacking)
        {
            Vector3 directionToTarget = transform.position - target.GetTransform().position;
            float angle = Vector3.Angle(transform.forward, directionToTarget);

            if (Mathf.Abs(angle) < 90)
            {
                m_IsAttacking = true;
                target.TakeDamage(target);
                return true;
            }
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

    public void SetName(string name)
    {
        if (m_TextMesh != null)
            m_TextMesh.text = name;
        else
            Debug.LogError("TextMesh Pro Component is null");
    }
}
