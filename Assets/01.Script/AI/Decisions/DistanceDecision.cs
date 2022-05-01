using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AIDecision
{
    [Range(0.1f, 30f)] [SerializeField] private float distance = 5f;
   
    public override bool MakeADecision()
    {
        float calc = Vector2.Distance(transform.position, enemyBrain.target.position);

        if(calc < distance)
        {
            if(!aiActionData.targetSpotted)
            {
                aiActionData.targetSpotted = true;
            }
        }
        else
        {
            aiActionData.targetSpotted = false;
        }

        return aiActionData.targetSpotted;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeGameObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, distance);
            Gizmos.color = Color.white;
        }
    }
#endif
}
