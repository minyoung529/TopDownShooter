using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 각 액션을 나타내는 객체
/// </summary>
public abstract class AIAction : MonoBehaviour
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

    public abstract void TakeAction();

    protected virtual void ChildAwake() { }
}
