using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    #region Data
    [SerializeField] protected WeaponDataSO weaponData;
    [SerializeField] protected GameObject muzzle; // �ѱ��� ��ġ
    [SerializeField] protected Transform shellEjectPos; // ź�� ���� ����
    #endregion

    public UnityEvent<int> OnAmmoChange;

    #region Ammo
    [SerializeField] protected int ammo; // ���� �Ѿ� ��
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
    public int EmptyBulletCount { get => weaponData.ammoCapacity - Ammo; } // ������ źȯ �� ��ȯ
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
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if(isShooting && !delayCoroutine)
        {
            if(Ammo > 0 || weaponData.infiniteAmmo)
            {
                if(!weaponData.infiniteAmmo)
                {
                    Ammo--;
                }

                OnShoot?.Invoke();

                for(int i = 0; i<weaponData.GetBulletCount(); i++)
                {
                    ShootBullet();
                }
            }
        }
        else
        {
            isShooting = false;
            OnShootNoAmmo?.Invoke();
            return;
        }

        FinishShooting(); // �� �� ����� ���������� ������ �� ��
    }

    protected void FinishShooting()
    {
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
        Debug.Log("Shoot");
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
