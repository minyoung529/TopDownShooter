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
    private int bulletLayer;

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
        bulletLayer = LayerMask.NameToLayer("Bullet");
    }

    private void FixedUpdate()
    {
        timeToLive += Time.fixedDeltaTime;

        if (timeToLive > bulletData.lifeTime)
        {
            isDead = true;
            PoolManager.Instance.Push(this);
        }

        if (rigid != null && bulletData != null)
        {
            rigid.MovePosition(transform.position + bulletData.bulletSpeed * transform.right * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.layer == obstacleLayer)
        {
            Debug.Log("Wall");
            HitObstacle(collision);
        }
        else if (collision.gameObject.layer == enemyLayer)
        {
            HitEnemy(collision);
        }

        if (bulletData.goThourghHit || collision.gameObject.layer == bulletLayer) return;

        isDead = true;
        PoolManager.Instance.Push(this);
    }

    private void HitEnemy(Collider2D collider)
    {

    }

    private void HitObstacle(Collider2D collider)
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction);

        if(hitInfo.collider != null)
        {
            ImpactScript impact = PoolManager.Instance.Pop(bulletData.impactObstaclePrefab.name) as ImpactScript;

            Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            impact.SetPosAndRot(hitInfo.point + (Vector2)transform.right * 0.5f, randomRot);
        }
    }

    public override void Reset()
    {
        damageFactor = 1;
        timeToLive = 0f;
        isDead = false;
    }
}
