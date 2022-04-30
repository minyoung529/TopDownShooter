using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/BulletData")]
public class BulletDataSO : ScriptableObject
{
    public GameObject prefab;
    [Range(1, 10)] public int damage = 1;
    [Range(1, 100f)] public float bulletSpeed = 1;

    // Æø¹ßÅºÀÏ °æ¿ì
    [Range(0, 5f)] public float explosionRadius = 3f; // Æø¹ß ¹İ°æ

    public Sprite bulletSprite;
    public RuntimeAnimatorController animatorController;

    public float friction = 0f;
    public bool bounce = false; // ºÎµúÇûÀ» ¶§ Æ¨±èÀÇ ¿©ºÎ
    public bool goThourghHit = false;
    public bool isRayCast = false; // ex Àú°İÃÑ
    public bool isCharging = false; // Â÷Â¡ ÃÑ¾Ë

    public GameObject impactObstaclePrefab; // Àå¾Ö¹° ºÎµúÇûÀ» ¶§ ³ª¿Ã ÀÌÆåÆ®
    public GameObject impactEnemyPrefab; // Àû¿¡ ºÎµúÇûÀ» ¶§ ³ª¿Ã ÀÌÆåÆ®

    [Range(1, 20)] public float knockBackPower = 5f;
    [Range(0.01f, 1f)] public float knockBackDelay = 0.01f;

    public Material bulletMat;

    public float lifeTime = 2f;
}
