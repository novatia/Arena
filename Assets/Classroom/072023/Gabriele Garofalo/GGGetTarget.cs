using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MBT;

namespace MBTExample
{

    [AddComponentMenu("")]
    [MBTNode("Gabriele Garofalo/Get target", 500)]
    public class GGGetTarget : Leaf
    {
        private GGPlayer m_myself;

        private void Start()
        {
            m_myself = GetComponentInParent<GGPlayer>();
            
        }


        public override NodeResult Execute()
        {
            Debug.Log("get target");
            //Debug.Log(m_myself.Data.TargetPosition);

            m_myself.Block();

            if (m_myself.transform.position != m_myself.Data.TargetPosition)
            {
                Vector2 randomPosition = Random.insideUnitCircle * 40f;
                m_myself.Data.TargetPosition = new Vector3(500f, 0f, 500f) + new Vector3(randomPosition.x, 0f, randomPosition.y);
            }


            //Debug.Log(m_myself.Data.TargetPosition);

            return NodeResult.success;
        }


    }
}
