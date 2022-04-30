using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RegularBullet : Bullet
{
    protected Rigidbody2D rigid;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected float timeToLive;

    private int enemyLayer;
    private int obstacleLayer;

    private bool isDead = false; // 한 개의 총알이 여러명에 적에 영향주는 것을 막기 위함

    public override BulletDataSO BulletData
    {
        get => bulletData;
        set
        {
            base.BulletData = value;
            bulletData = value;

            rigid ??= GetComponent<Rigidbody2D>();
            rigid.drag = bulletData.friction;

            spriteRenderer ??= GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = bulletData.bulletSprite;
            spriteRenderer.material = bulletData.bulletMat;

            animator ??= GetComponent<Animator>();
            animator.runtimeAnimatorController = bulletData.animatorController;

            if (IsEnemy)
                enemyLayer = LayerMask.NameToLayer("Player");
            else
                enemyLayer = LayerMask.NameToLayer("Enemy");
        }
    }

    private void Awake()
    {
        obstacleLayer = LayerMask.NameToLayer("Obstacle");
    }

    private void FixedUpdate()
    {
        timeToLive += Time.fixedDeltaTime;

        if(timeToLive > bulletData.lifeTime)
        {
            isDead = true;
            PoolManager.Instance.Push(this);
        }

        if(rigid != null && bulletData != null)
        {
            rigid.MovePosition(transform.position + bulletData.bulletSpeed * transform.right * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public override void Reset()
    {
        damageFactor = 1;
        timeToLive = 0f;
        isDead = false;
    }
}
