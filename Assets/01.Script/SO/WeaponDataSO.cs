using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public GameObject prefab;

    public BulletDataSO bulletData;

    /// <summary>
    /// 탄창 크기
    /// </summary>
    [Range(0, 999)] public int ammoCapacity;

    /// <summary>
    /// 연사 
    /// </summary>
    public bool automaticFire;

    [Range(0.1f, 2f)] public float weaponDelay;

    /// <summary>
    /// 탄이 퍼지는, 총알이 흔들리는 각도
    /// </summary>
    [Range(0, 10f)] public float spreadAngle = 5f;

    /// <summary>
    /// 한번 슈팅에 여러 발 발사(샷건)
    /// </summary>
    public bool multiBulletShoot = false;

    [SerializeField] private int bulletcount = 1;
    public int damageFactor = 1;

    [Range(0.1f, 2f)] public float reloadTime = 0.1f;

    public AudioClip shootClip;
    public AudioClip outOfAmmoClip;
    public AudioClip reloadClip;
    public Sprite sprite;

    /// <summary>
    /// 무한 탄창
    /// </summary>
    public bool infiniteAmmo = false;

    public int GetBulletCount()
    {
        if (multiBulletShoot)
        {
            return bulletcount;
        }
        else
        {
            return 1;
        }
    }
}
