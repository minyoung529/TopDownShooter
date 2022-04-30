using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/BulletData")]
public class BulletDataSO : ScriptableObject
{
    public GameObject prefab;
    [Range(1, 10)] public int damage = 1;
    [Range(1, 100f)] public float bulletSpeed = 1;

    // ����ź�� ���
    [Range(0, 5f)] public float explosionRadius = 3f; // ���� �ݰ�

    public Sprite bulletSprite;
    public RuntimeAnimatorController animatorController;

    public float friction = 0f;
    public bool bounce = false; // �ε����� �� ƨ���� ����
    public bool goThourghHit = false;
    public bool isRayCast = false; // ex ������
    public bool isCharging = false; // ��¡ �Ѿ�

    public GameObject impactObstaclePrefab; // ��ֹ� �ε����� �� ���� ����Ʈ
    public GameObject impactEnemyPrefab; // ���� �ε����� �� ���� ����Ʈ

    [Range(1, 20)] public float knockBackPower = 5f;
    [Range(0.01f, 1f)] public float knockBackDelay = 0.01f;

    public Material bulletMat;

    public float lifeTime = 2f;
}
