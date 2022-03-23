using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimation : MonoBehaviour
{
    protected Animator agentAnimator;

    //Hash
    //ó������ hashing���ֱ� ������ �ӵ� ����
    protected readonly int walkHastStr = Animator.StringToHash("Walk");
    protected readonly int deathHastStr = Animator.StringToHash("Death");

    private void Awake()
    {
        agentAnimator = GetComponent<Animator>();
    }

    public void SetWalkAnimation(bool value)
    {
        agentAnimator.SetBool(walkHastStr, value);
    }

    public void AnimatePlayer(float velocity)
    {
        SetWalkAnimation(velocity > 0f);
    }

    public void PlayerDeathAnimation()
    {
        agentAnimator.SetTrigger(deathHastStr);
    }
}
