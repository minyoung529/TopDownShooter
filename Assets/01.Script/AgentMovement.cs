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

    public UnityEvent<float> OnVelocityChange; // �ӵ��� �ٲ� ����� �̺�Ʈ

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        //Ű�� ������ ��
        if (movementInput.sqrMagnitude > 0f)
        {
            //theta�� 180 �̻�, PI/2 ~ 3PI/2
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
        //Ű�� ��������
        if (movementInput.sqrMagnitude > 0f)
        {
            //����
            currentVelocity += movementSO.acceleration * Time.deltaTime;
        }
        else
        {
            //����
            currentVelocity -= movementSO.deAcceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0f, movementSO.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange.Invoke(currentVelocity);
        rigid.velocity = movementDirection * currentVelocity;
    }

    //�˹� ���� �� ��� ����
    public void StopImmediatelly()
    {
        currentVelocity = 0f;
        rigid.velocity = Vector2.zero;
    }
}
