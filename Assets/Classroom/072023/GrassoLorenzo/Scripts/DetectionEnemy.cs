using UnityEngine;
using MBT;
using System.Collections.Generic;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("Grasso Lorenzo/Detect Enemy Service")]
    public class DetectionEnemy : Service
    {
        public LayerMask mask;
        public float range;
        LGIArenaPlayer m_Player;

        private void Start()
        {
            m_Player = GetComponentInParent<LGIArenaPlayer>();
            m_Player.Enemies.Clear();
        }

        public override void Task()
        {

            // Find target in radius and feed blackboard variable with results
            Collider[] colliders = Physics.OverlapSphere(transform.position, range, mask, QueryTriggerInteraction.Ignore);
            if (colliders.Length > 0)
            {
                foreach (var collider in colliders)
                {
                    if (!collider.TryGetComponent(out LGIArenaPlayer lGIArenaPlayer)) m_Player.Enemies.Add(collider.gameObject);


                }
            }
            else
            {
                m_Player.Enemies.Clear();
            }

        }

    

    }

    
}

