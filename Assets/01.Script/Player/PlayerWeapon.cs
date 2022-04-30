using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : AgentWeapon
{
    // TODO: Weapon Exchange, Drop, Obtain Code

    // Delete Later
    public PoolableMono bulletPrefab;

    protected void Start()
    {
        //base.AwakeChild();
        PoolManager.Instance.CreatePool(bulletPrefab, 20);
    }
}
