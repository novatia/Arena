namespace DenisFaraci.Nodes
{
    using MBT;
    using UnityEngine;

    [MBTNode("DF/AttackTarget")]
    [AddComponentMenu("")]
    public class AttackTarget : Leaf
    {
        public IArenaPlayer player;
        public TransformReference target;

        public override NodeResult Execute()
        {
            if (target.Value.TryGetComponent(out IArenaInterface arenaTarget))
            {
                player.Attack(arenaTarget);
                return NodeResult.success;
            }
            return NodeResult.failure;
        }
    }
}