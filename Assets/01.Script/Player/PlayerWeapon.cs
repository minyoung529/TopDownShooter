using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : AgentWeapon
{
    // TODO: Weapon Exchange, Drop, Obtain Code

    public UnityEvent<int, int> OnChangeTotalAmmo { get; set; } // 현재 값, 최대 값

    [SerializeField] private ReloadGaugeUI reloadUI;
    [SerializeField] private AudioClip cannotSound;

    [SerializeField] private int maxTotalAmmo = 2000;
    [SerializeField] private int totalAmmo = 200;

    public bool AmmoFull
    {
        get => totalAmmo == maxTotalAmmo;
    }

    public int TotalAmmo
    {
        get => totalAmmo;
        set
        {
            totalAmmo = Mathf.Clamp(value, 0, maxTotalAmmo);
            OnChangeTotalAmmo?.Invoke(totalAmmo, maxTotalAmmo);
        }
    }

    private AudioSource audioSource;
    private bool isReloading = false;
    public bool IsReloading { get => isReloading; }

    protected override void AwakeChild()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected void Start()
    {
        OnChangeTotalAmmo?.Invoke(totalAmmo, maxTotalAmmo);
    }

    public void ReloadGun()
    {
        if(weapon != null && !isReloading && totalAmmo > 0 && !weapon.AmmoFull)
        {
            isReloading = true;
            weapon.StopShooting();
            StartCoroutine(ReloadCoroutine());
        }
        else
        {
            PlayClip(cannotSound);
        }
    }

    private void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    private IEnumerator ReloadCoroutine()
    {
        reloadUI.gameObject.SetActive(true);
        float time = 0f;

        while(time < weapon.WeaponData.reloadTime)
        {
            reloadUI.ReloadGaugeNormal(time / weapon.WeaponData.reloadTime);
            time += Time.deltaTime;
            yield return null;
        }

        reloadUI.gameObject.SetActive(false);
        PlayClip(weapon.WeaponData.reloadClip);

        int reloadedAmmo = Mathf.Min(TotalAmmo, weapon.EmptyBulletCount);
        // 현재 총 부족한 분량과 남은 총탄 중 작은 분량으로 선택

        TotalAmmo -= reloadedAmmo;
        weapon.Ammo += reloadedAmmo;

        isReloading = false;
    }

    public override void Shoot()
    {
        if(weapon == null)
        {
            PlayClip(cannotSound);
            return;
        }
        else if(isReloading)
        {
            PlayClip(weapon.WeaponData.outOfAmmoClip);
            return;
        }

        base.Shoot();
    }
}
