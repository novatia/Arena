using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
public class LGIArenaPlayer : IArenaPlayer, IArenaInterface
{

    public List<GameObject> Enemies = new List<GameObject>();




}

