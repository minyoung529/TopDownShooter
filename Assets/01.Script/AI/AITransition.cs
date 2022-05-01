using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    // 결정해야할 것들의 리스트
    public List<AIDecision> decisions;

    public AIState positiveState;
    public AIState negativeState;
}
