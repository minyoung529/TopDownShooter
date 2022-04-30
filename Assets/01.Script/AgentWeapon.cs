using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon weapon;
    protected WeaponRenderer weaponRenderer;
    // 무기 바라보는 방향
    protected float desireAngle;

    void Awake()
    {
        AssignWeapon();
        AwakeChild();
    }

    protected virtual void AwakeChild() { }

    public virtual void AssignWeapon()
    {
        weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        weapon = GetComponentInChildren<Weapon>();
    }

    public virtual void AimWeapon(Vector2 mouseInput)
    {
        if (weapon == null) return;

        Vector3 aimDirection = (Vector3)mouseInput - transform.position;
        desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        AdjustWeaponRendering();

        transform.rotation = Quaternion.AngleAxis(desireAngle, Vector3.forward);
    }

    private void AdjustWeaponRendering()
    {
        if (weaponRenderer == null) return;

        weaponRenderer.FlipSprite(desireAngle > 90f || desireAngle < -90f);
        weaponRenderer.RenderBehindHead(desireAngle > 0f && desireAngle < 180f);
    }

    public virtual void Shoot()
    {
        if (weapon = null) return;

        weapon.TryShooting();
    }

    public virtual void StopShooting()
    {
        if (weapon = null) return;

        weapon.StopShooting();
    }
}
