using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchAnimation : MonoBehaviour
{
    [SerializeField] private bool changeRadius; //��鸱 �� �ݰ���� ��鸱 �ų�

    [SerializeField] private float intensityRandomness;
    [SerializeField] private float radiusRandomness;
    [SerializeField] private float timeRandomness;

    private float baseIntensity;
    private float baseTime = 0.5f;
    private float baseRadius;

    private Light2D light;

    private void Awake()
    {
        light = GetComponentInChildren<Light2D>();
        baseIntensity = light.intensity;
        baseRadius = light.pointLightOuterRadius;
    }

    private void OnEnable()
    {
        ShakeLight();
    }

    private void ShakeLight()
    {
        // dotween sequence�� �ѹ� ���� ��礤��
        // �������� �ٽ� �� �� shake light

        if (!gameObject.activeSelf) return;

        float targetIntensity = baseIntensity + Random.Range(-intensityRandomness, intensityRandomness);
        float targetTime = baseTime + Random.Range(-timeRandomness, timeRandomness);
        float targetRadius = baseRadius + Random.Range(-radiusRandomness, radiusRandomness);

        Sequence seq = DOTween.Sequence();

        seq.Append(DOTween.To(
            //get
            () => light.intensity,
            //set
            value => light.intensity = value,
            //result
            targetIntensity,
            //time
            targetTime));

        if (changeRadius)
        {
            seq.Append(
                DOTween.To(
                () => light.pointLightOuterRadius,
                value => light.pointLightOuterRadius = value,
                targetRadius,
                targetTime
                ));
        }

        seq.AppendCallback(() => ShakeLight());
    }
}
