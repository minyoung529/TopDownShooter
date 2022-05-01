using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.direction = Vector2.zero;
        aiMovementData.pointOfInterest = transform.position;
        enemyBrain.Move(aiMovementData.direction, aiMovementData.pointOfInterest);
    }
}
