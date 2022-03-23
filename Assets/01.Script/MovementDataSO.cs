using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Agent/MovementData")]
public class MovementDataSO : ScriptableObject
{
    [Range(1, 10)]
    public float maxSpeed = 5f;

    [Range(0.1f, 100f)]
    public float acceleration = 50f, deAcceleration = 50f;

}
