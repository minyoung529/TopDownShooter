using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        Vector2 direction = enemyBrain.target.position - transform.position;
        aiMovementData.direction = direction.normalized;
        aiMovementData.pointOfInterest = enemyBrain.target.position;

        enemyBrain.Move(aiMovementData.direction, aiMovementData.pointOfInterest);
    }
}
