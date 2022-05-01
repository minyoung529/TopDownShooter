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

    // �� �����Ӹ��� ���� ���� ����
    public void UpdateState()
    {
        // �� ���¿��� ������ �׼��� ���� ����
        foreach (AIAction action in actions)
        {
            action.TakeAction();
        }

        // ���� ���¿��� �ٸ� ���·� ���̰� �̷������ϴ��� üũ�ϰ�
        // �׿� ���� ���̸� ����Ű�ų� ���� �ִ´�.
        foreach (AITransition transition in transitions)
        {
            bool result = false;

            foreach (AIDecision decision in transition.decisions)
            {
                result = decision.MakeADecision();
                if (!result) break;
            }

            if (result) // ��� ������ ����
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
