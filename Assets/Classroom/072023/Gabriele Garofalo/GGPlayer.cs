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
        SetName("Gabevlogd");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IArenaInterface enemy))
        {
            Data.TargetEnemy = enemy;
            Block();
        }
    }
}

public struct Data
{
    public Vector3 TargetPosition;
    public NavMeshAgent NavMesh;
    public IArenaInterface TargetEnemy;
}
