using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MBT;

namespace MBT
{
    [AddComponentMenu("")]
    [MBTNode(name = "Michele Grassano/Move Towards Target Node", order = 2)]
    public class MG_MoveTowardsTargetNode : Leaf
    {
        [SerializeField]
        private float detectionRadius = 10f;
        public LayerMask mask;
        private bool isMoving = false;
        private Transform playerPosition;

        public override NodeResult Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
