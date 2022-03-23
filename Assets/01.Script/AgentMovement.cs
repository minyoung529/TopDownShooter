using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField] private MovementDataSO movementSO;

    protected float currentVelocity = 3f;
    protected Vector2 movementDirection;

    public UnityEvent<float> OnVelocityChange; // 속도가 바뀔때 실행될 이벤트

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        //키가 눌렸을 때
        if (movementInput.sqrMagnitude > 0f)
        {
            //theta가 180 이상, PI/2 ~ 3PI/2
            if (Vector2.Dot(movementInput, movementDirection) < 0f)
            {
                currentVelocity = 0f;
            }

            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        //키를 눌렀으면
        if (movementInput.sqrMagnitude > 0f)
        {
            //가속
            currentVelocity += movementSO.acceleration * Time.deltaTime;
        }
        else
        {
            //감속
            currentVelocity -= movementSO.deAcceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0f, movementSO.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange.Invoke(currentVelocity);
        rigid.velocity = movementDirection * currentVelocity;
    }

    //넉백 구현 때 사용 예정
    public void StopImmediatelly()
    {
        currentVelocity = 0f;
        rigid.velocity = Vector2.zero;
    }
}
