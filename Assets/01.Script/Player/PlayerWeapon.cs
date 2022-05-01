using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : AgentWeapon
{
    // TODO: Weapon Exchange, Drop, Obtain Code

    // Delete Later
    public PoolableMono bulletPrefab;
    public PoolableMono impactPrefab;

    protected void Start()
    {
        //base.AwakeChild();
        PoolManager.Instance.CreatePool(bulletPrefab, 20);
        PoolManager.Instance.CreatePool(impactPrefab, 20);
    }
}
