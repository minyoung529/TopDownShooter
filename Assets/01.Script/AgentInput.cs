using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;

// 기능과 인풋을 분리한다는 게 의의
public class AgentInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> OnPointerPositionChange;

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
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

        OnPointerPositionChange?.Invoke(mouseInWorldPos );
    }
}
