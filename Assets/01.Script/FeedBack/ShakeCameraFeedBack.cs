using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCameraFeedBack : FeedBack
{
    [SerializeField] CinemachineVirtualCamera cmVcam;
    [SerializeField]
    [Range(0, 5f)]
    private float amplitude, intensity;

    [SerializeField]
    [Range(0, 1f)]
    private float duration;

    private CinemachineBasicMultiChannelPerlin noise;

    private void OnEnable()
    {
        cmVcam ??= Define.VCam;
        noise = cmVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public override void CompletePrevFeedBack()
    {
        StopAllCoroutines();
        noise.m_AmplitudeGain = 0f;
    }

    public override void CreateFeedBack()
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = intensity;
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float time = duration;

        while (time > 0f)
        {
            noise.m_AmplitudeGain = Mathf.Lerp(0f, amplitude, time / duration);
            yield return null;
            time -= Time.deltaTime;
        }

        noise.m_AmplitudeGain = 0f;
    }
}
