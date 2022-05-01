using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private EnemyAIBrain enemyBrain;
    public List<AIAction> actions;
    public List<AITransition> transitions;

    private void Awake()
    {
        enemyBrain = GetComponentInParent<EnemyAIBrain>();

        //GetComponents(actions);
        //GetComponentsInChildren(transitions);
    }

    // 매 프레임마다 현재 상태 갱신
    public void UpdateState()
    {
        // 내 상태에서 수행할 액션을 전부 수행
        foreach (AIAction action in actions)
        {
            action.TakeAction();
        }

        // 현재 상태에서 다른 상태로 전이가 이뤄져야하는지 체크하고
        // 그에 따라 전이를 일으키거나 가만 있는다.
        foreach (AITransition transition in transitions)
        {
            bool result = false;

            foreach (AIDecision decision in transition.decisions)
            {
                result = decision.MakeADecision();
                if (!result) break;
            }

            if (result) // 모든 조건이 성공
            {
                if(transition.positiveState != null)
                {
                    enemyBrain.ChangeState(transition.positiveState);
                }
            }
            else
            {
                if (transition.negativeState != null)
                {
                    enemyBrain.ChangeState(transition.negativeState);
                }
            }
        }
    }
}
