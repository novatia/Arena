using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GMArenaPlayer : IArenaPlayer
{
    private List<GameObject> m_OthersPlayerList;
    public List<GameObject> OthersPlayerList { get => m_OthersPlayerList;}

    private GameObject m_ActualTarget;
    public GameObject ActualTarget { get => m_ActualTarget; set => m_ActualTarget = value; }
}
