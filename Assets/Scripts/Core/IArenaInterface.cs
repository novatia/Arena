using UnityEngine;

public interface IArenaInterface
{
    /// <summary>
    /// DO NOT OVERRIDE
    /// Set player in blocking position, speed and damage is halved
    /// </summary>
    /// <returns></returns>
    public bool Block();

    /// <summary>
    /// DO NOT OVERRIDE
    /// Set player in blocking position, speed and damage is halved
    /// </summary>
    /// <returns></returns>
    public bool Unblock();


    /// <summary>
    /// DO NOT OVERRIDE
    /// Try to give damage to target
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool Attack(IArenaInterface target);

    /// <summary>
    /// DO NOT OVERRIDE
    /// Wrapper to NavMesh Agent Move 
    /// </summary>
    /// <param name="offset"></param>
    /// <returns></returns>
    public bool MoveTo(Vector3 offset);

    /// <summary>
    /// DO NOT OVERRIDE
    /// Jump.
    /// </summary>
    /// <returns></returns>
    public bool Jump();


    /// <summary>
    /// DO NOT OVERRIDE
    /// Set the player name, call it once
    /// </summary>
    /// <param name="name"></param>
    public void SetName(string name);



    /// <summary>
    /// DO NOT OVERRIDE
    /// Not usefull for you
    /// </summary>
    /// <returns></returns>
    public Transform GetTransform();

    /// <summary>
    /// DO NOT OVERRIDE
    /// Not usefull for you.
    /// </summary>
    /// <returns></returns>
    public void TakeDamage(IArenaInterface target);


}