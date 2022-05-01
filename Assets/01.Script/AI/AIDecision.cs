using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����ش�
/// </summary>
public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData aiActionData;
    protected AIMovementData aiMovementData;
    protected EnemyAIBrain enemyBrain;

    private void Awake()
    {
        aiActionData = GetComponentInParent<AIActionData>();
        aiMovementData = GetComponentInParent<AIMovementData>();
        enemyBrain = GetComponentInParent<EnemyAIBrain>();

        ChildAwake();
    }

    protected virtual void ChildAwake() { }

    public abstract bool MakeADecision();
}
