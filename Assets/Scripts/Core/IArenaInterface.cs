using UnityEngine;

public interface IArenaInterface
{
    public void TakeDamage();
    protected bool Block();
    protected bool Attack(IArenaInterface target);
    protected bool MoveTo(Vector3 offset);
    public Transform GetTransform();
}