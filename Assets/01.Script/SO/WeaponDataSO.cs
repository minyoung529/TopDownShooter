using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public GameObject prefab;

    public BulletDataSO bulletData;

    /// <summary>
    /// źâ ũ��
    /// </summary>
    [Range(0, 999)] public int ammoCapacity;

    /// <summary>
    /// ���� 
    /// </summary>
    public bool automaticFire;

    [Range(0.1f, 2f)] public float weaponDelay;

    /// <summary>
    /// ź�� ������, �Ѿ��� ��鸮�� ����
    /// </summary>
    [Range(0, 10f)] public float spreadAngle = 5f;

    /// <summary>
    /// �ѹ� ���ÿ� ���� �� �߻�(����)
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
    /// ���� źâ
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
