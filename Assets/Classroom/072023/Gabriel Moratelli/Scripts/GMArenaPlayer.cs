using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GMArenaPlayer : IArenaPlayer
{
    private List<GameObject> m_OthersPlayerList;
    public List<GameObject> OthersPlayerList { get => m_OthersPlayerList;}

    private GameObject m_ActualTarget;
    public GameObject ActualTarget { get => m_ActualTarget; set => m_ActualTarget = value; }

    private bool m_IsTargetNear;
    public bool IsTargetNear { get => m_IsTargetNear; set => m_IsTargetNear = value; }

    private void Start()
    {
        m_OthersPlayerList = new List<GameObject>();
    }
}
