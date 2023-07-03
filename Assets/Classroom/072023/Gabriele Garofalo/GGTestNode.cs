using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;

namespace MBTExample
{

    [AddComponentMenu("")]
    [MBTNode("Gabriele Garofalo/Test Node", 500)]
    public class GGTestNode : Leaf
    {
        public override NodeResult Execute()
        {
            Debug.Log("test");
            return NodeResult.running;
        }


    }
}