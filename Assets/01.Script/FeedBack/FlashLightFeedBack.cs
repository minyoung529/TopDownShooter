using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightFeedBack : FeedBack
{
    [SerializeField] private Light2D lightTarget;
    [SerializeField] private float lightOnDelay = 0.01f;
    [SerializeField] private float lightOffDelay = 0.01f;
    [SerializeField] private bool defaultStatus = false;

    public override void CompletePrevFeedBack()
    {
        StopAllCoroutines(); // 자신의 코루틴만 정지
        lightTarget.enabled = defaultStatus;
    }

    public override void CreateFeedBack()
    {
        StartCoroutine(ToggleLightCoroutine(lightOnDelay, true, () =>
        {
            StartCoroutine(ToggleLightCoroutine(lightOffDelay, false));
        }));
    }

    private IEnumerator ToggleLightCoroutine(float time, bool result, Action FinishCallBack = null)
    {
        yield return new WaitForSeconds(time);
        lightTarget.enabled = result;
        FinishCallBack?.Invoke();
    }
}
