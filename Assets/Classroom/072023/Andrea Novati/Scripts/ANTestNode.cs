using MBT;
using UnityEngine;

namespace MBTExample
{
    namespace Nov41337
    {
        [AddComponentMenu("")]
        [MBTNode("Andrea Novati/Test", 500)]
        public class ANTestNode : Leaf
        {
            public override NodeResult Execute()
            {
                Debug.Log("hey");
                return NodeResult.running;
            }
        }
    }
}