using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] protected int characterSortingOrder = 0;
    protected SpriteRenderer weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool isFlip)
    {
        Vector3 localScale = Vector3.one;

        if (isFlip)
            localScale.y = -1f;

        transform.localScale = localScale;
    }

    public void RenderBehindHead(bool isBehind)
    {
        if (isBehind)
        {
            weaponRenderer.sortingOrder = characterSortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterSortingOrder + 1;
        }
    }
}
