using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        Vector2 mouseInWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        OnPointerPositionChange?.Invoke(mousePos);
    }
}
