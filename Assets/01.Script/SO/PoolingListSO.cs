using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/System/PoolingList")]
public class PoolingListSO : ScriptableObject
{
    public List<PoolingPair> list;
}

[System.Serializable]
public class PoolingPair
{
    public PoolableMono prefab;
    public int poolCnt;
}