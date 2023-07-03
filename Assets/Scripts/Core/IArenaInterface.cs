using UnityEngine;

public interface IArenaInterface
{
    /// <summary>
    /// Set player in blocking position, speed and damage is halved
    /// </summary>
    /// <returns></returns>
    public bool Block();

    /// <summary>
    /// Try to give damage to target
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool Attack(IArenaInterface target);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="offset"></param>
    /// <returns></returns>
    public bool MoveTo(Vector3 offset);

    /// <summary>
    /// Jump.
    /// </summary>
    /// <returns></returns>
    public bool Jump();


    /// <summary>
    /// DO NOT OVERRIDE
    /// </summary>
    /// <returns></returns>
    protected Transform GetTransform();

    /// <summary>
    /// DO NOT OVERRIDE
    /// </summary>
    /// <returns></returns>
    protected void TakeDamage();
}