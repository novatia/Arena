using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;

namespace MBTExample
{

    [AddComponentMenu("")]
    [MBTNode("Gabriele Garofalo/Move to target", 500)]
    public class GGMoveToTarget : Leaf
    {

        private GGPlayer m_myself;

        private void Start()
        {
            m_myself = GetComponentInParent<GGPlayer>();
        }

        public override NodeResult Execute()
        {
            Debug.Log("Move to target");
            //Debug.Log(m_myself.Data.TargetPosition);


            bool requestResult = m_myself.Data.NavMesh.SetDestination(m_myself.Data.TargetPosition); /*= m_myself.Data.TargetPosition;*/

            if (!requestResult) return NodeResult.failure;

            if (Vector3.Distance(m_myself.transform.position, m_myself.Data.TargetPosition) <= 0.1f)
            {
                Debug.Log("Target reached");
                m_myself.transform.position = m_myself.Data.TargetPosition;
                return NodeResult.success;
            }

            if (m_myself.Data.TargetEnemy != null) m_myself.Attack(m_myself.Data.TargetEnemy);
            

            return NodeResult.running;

        }


    }
}