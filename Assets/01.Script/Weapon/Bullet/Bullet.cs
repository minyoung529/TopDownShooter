using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : PoolableMono
{
    [SerializeField]
    protected BulletDataSO bulletData;
    public virtual BulletDataSO BulletData
    {
        get => bulletData;
        set
        {
            bulletData = value;
            damageFactor = bulletData.damage;
        }
    }

    protected bool isEnemy;
    public bool IsEnemy { get => isEnemy; set { isEnemy = value; } }

    public int damageFactor = 1; // 총알의 데미지 계수

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }
}
