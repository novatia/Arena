using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GGPlayer : IArenaPlayer
{
    public Data Data;

    private void Start()
    {
        Data = new();
        Data.NavMesh = GetComponent<NavMeshAgent>();
    }
}

public struct Data
{
    public Vector3 TargetPosition;
    public NavMeshAgent NavMesh;
}
