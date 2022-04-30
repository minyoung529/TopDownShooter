using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;

// ��ɰ� ��ǲ�� �и��Ѵٴ� �� ����
public class AgentInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> OnPointerPositionChange;

    // �ܹ��� ��, ����� ó��
    public UnityEvent OnFireButtonPress;
    public UnityEvent OnFireButtonRelease;

    private bool fireButtonDown = false;

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
    }

    private void GetMovementInput()
    {
        OnMovementKeyPress?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        //LATER::FIX
        Vector2 mouseInWorldPos = Define.MainCam.ScreenToWorldPoint(mousePos);

        OnPointerPositionChange?.Invoke(mouseInWorldPos);
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (!fireButtonDown)
            {
                fireButtonDown = true;
                OnFireButtonPress.Invoke();
            }
        }
        else
        {
            if (fireButtonDown)
            {
                fireButtonDown = false;
                OnFireButtonRelease.Invoke();
            }
        }
    }
}
