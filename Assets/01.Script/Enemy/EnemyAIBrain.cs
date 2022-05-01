using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour, IAgentInput
{
    [field:SerializeField] public UnityEvent<Vector2> OnMovementKeyPress { get; set; }
    [field:SerializeField] public UnityEvent<Vector2> OnPointerPositionChange { get; set; }
    [field:SerializeField] public UnityEvent OnFireButtonPress { get; set; }
    [field:SerializeField] public UnityEvent OnFireButtonRelease { get; set; }

    [SerializeField] private AIState currentState;

    public Transform target;

    void Start()
    {
        target = GameManager.Instance.PlayerTransform;
    }

    public void Attack()
    {
        OnFireButtonPress?.Invoke();
    }

    public void Move(Vector2 moveDirection, Vector2 targetPosition)
    {
        OnMovementKeyPress?.Invoke(moveDirection);
        OnPointerPositionChange?.Invoke(targetPosition);
    }

    public void ChangeState(AIState state)
    {
        currentState = state;
    }

    private void Update()
    {
        if(target == null)
        {
            OnMovementKeyPress?.Invoke(Vector2.zero);
        }
        else
        {
            currentState.UpdateState();
        }
    }
}