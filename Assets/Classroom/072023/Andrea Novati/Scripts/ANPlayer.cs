using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANPlayer : MonoBehaviour
{

    private IArenaPlayer m_Proxy;
    private GameObject m_Target;

    public GameObject Target => m_Target;

    public void SetTarget(GameObject target)
    {
        Debug.Log("NOV41337 TARGET ACQUIRED");
        
        m_Target = target;
    }

    // Start is called before the first frame update
    void Awake()
    {
        m_Proxy = GetComponent<IArenaPlayer>();
        m_Proxy.SetName("Nov41337");
    }

    public bool TargetIsDead()
    {
        if (Target == null)
            return false;

        return !Target.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
