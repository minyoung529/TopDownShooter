using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private PoolingListSO initList;

    private Transform playerTransform;
    public Transform PlayerTransform
    {
        get
        {
            if (playerTransform == null)
            {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }

            return playerTransform;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is running");
        }

        Instance = this;

        PoolManager.Instance = new PoolManager(transform);

        SetCursorIcon();
        CreatePool();
    }

    private void CreatePool()
    {
        foreach (PoolingPair pair in initList.list)
        {
            PoolManager.Instance.CreatePool(pair.prefab, pair.poolCnt);
        }
    }

    private void SetCursorIcon()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width * 0.5f, cursorTexture.height * 0.5f), CursorMode.Auto);
    }
}
