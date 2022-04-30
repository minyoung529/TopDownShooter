using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    private Dictionary<string, Pool<PoolableMono>> pools = new Dictionary<string, Pool<PoolableMono>>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple PoolManager is running!");
        }

        Instance = this;
    }

    public void CreatePool(PoolableMono prefab, int count = 10)
    {
        Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, transform);
        pools.Add(prefab.gameObject.name, pool);
    }

    public PoolableMono Pop(string prefabName)
    {
        if (!pools.ContainsKey(prefabName))
        {
            Debug.LogError("Prefab doesn't exist on pool");
            return null;
        }

        PoolableMono item = pools[prefabName].Pop();
        item.Reset();
        return item;
    }

    public void Push(PoolableMono obj)
    {
        obj.Reset();
    
        if (!pools.ContainsKey(obj.name))
        {
            Pool<PoolableMono> pool = new Pool<PoolableMono>(obj, transform);
            pools.Add(obj.name.Trim(), pool);
        }

        //trim => 앞뒤 공백 제거
        pools[obj.name.Trim()].Push(obj);
    }
}
