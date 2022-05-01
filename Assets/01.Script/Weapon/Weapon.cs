using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    #region Data
    [SerializeField] protected WeaponDataSO weaponData;
    [SerializeField] protected GameObject muzzle; // 총구의 위치
    [SerializeField] protected Transform shellEjectPos; // 탄피 생성 지점
    [SerializeField] protected bool isEnemyWeapon = false; // 탄피 생성 지점
    #endregion

    public UnityEvent<int> OnAmmoChange;

    #region Ammo
    [SerializeField] protected int ammo; // 현재 총알 수
    public int Ammo
    {
        get
        {
            if (weaponData.infiniteAmmo) return -1;
            else return ammo;
        }
        set
        {
            ammo = Mathf.Clamp(value, 0, weaponData.ammoCapacity);
            OnAmmoChange.Invoke(ammo);
        }
    }

    public bool AmmoFull { get => Ammo == weaponData.ammoCapacity || weaponData.infiniteAmmo; }
    public int EmptyBulletCount { get => weaponData.ammoCapacity - Ammo; } // 부족한 탄환 수 반환
    #endregion

    #region Fire
    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;

    protected bool isShooting;
    [SerializeField] protected bool delayCoroutine = false;
    #endregion

    private void Awake()
    {
        ammo = weaponData.ammoCapacity;
        WeaponAudio weaponAudio = transform.Find("WeaponAudio").GetComponentInChildren<WeaponAudio>();
        weaponAudio.SetAudioClip(weaponData.shootClip, weaponData.outOfAmmoClip, weaponData.reloadClip);
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && !delayCoroutine)
        {
            if (Ammo > 0 || weaponData.infiniteAmmo)
            {
                if (!weaponData.infiniteAmmo)
                {
                    Ammo--;
                }

                OnShoot?.Invoke();

                for (int i = 0; i < weaponData.GetBulletCount(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
        }

        FinishShooting(); // 한 발 사격을 성공적으로 끝내고 난 뒤
    }

    protected void FinishShooting()
    {
        if (!delayCoroutine)
            StartCoroutine(DelayNextShootCoroutine());

        if (!weaponData.automaticFire)
        {
            isShooting = false;
        }
    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        delayCoroutine = true;
        yield return new WaitForSeconds(weaponData.weaponDelay);
        delayCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle), isEnemyWeapon);
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-weaponData.spreadAngle, weaponData.spreadAngle);
        Quaternion spreadRot = Quaternion.Euler(0f, 0f, spread);

        return muzzle.transform.rotation * spreadRot;
    }

    private void SpawnBullet(Vector3 pos, Quaternion rot, bool isEnemy)
    {
        Bullet obj = PoolManager.Instance.Pop(weaponData.bulletData.prefab.name) as Bullet;
        obj.SetPositionAndRotation(pos, rot);
        obj.BulletData = weaponData.bulletData;
        obj.IsEnemy = isEnemy;
    }

    public void TryShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }
}
