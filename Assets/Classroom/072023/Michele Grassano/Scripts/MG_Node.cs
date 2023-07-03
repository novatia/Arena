using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;

namespace MBT
{
    [AddComponentMenu("")]
    [MBTNode(name = "Michele Grassano/Node", order = 1)]
    public class MG_Node : Leaf
    {
        public override NodeResult Execute()
        {
            return NodeResult.failure;
        }
    }
}
