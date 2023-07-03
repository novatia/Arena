using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
public class IArenaPlayer : MonoBehaviour,IArenaInterface
{

    [Range(1,100)]
    public int MaxHealth;

    private Rigidbody m_Rigidbody;
    private CapsuleCollider m_CapsuleCollider;
    private NavMeshAgent m_NavMeshAgent;
    private int m_CurrentHealth;
    private bool m_Blocking;

    [Range(1f,20f)]
    public float AttackDamage = 10.0f;

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
        
    }

   
    void IArenaInterface.TakeDamage()
    {
        if (m_Blocking)
            m_CurrentHealth -= Mathf.RoundToInt( AttackDamage/2.0f );
        else
            m_CurrentHealth -= Mathf.RoundToInt( AttackDamage );
    }

    bool IArenaInterface.Block()
    {
        return false;
    }

    bool IArenaInterface.Attack(IArenaInterface target)
    {
        
        return false;
    }

    bool IArenaInterface.MoveTo(Vector3 offset)
    {
        m_NavMeshAgent.Move(offset);

        return true;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public bool Jump()
    {
        throw new System.NotImplementedException();
    }
}
