using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeFeedBack : FeedBack
{
    [SerializeField] private GameObject objectToShake;
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float strength = 1f;
    [SerializeField] private float randomness = 90;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private bool snapping = false;
    [SerializeField] private bool fadeOut = false;
    //snapping => 격자 단위 떨림
    //fadeOut => 원래 자리로 돌아감

    public override void CompletePrevFeedBack()
    {
        objectToShake.transform.DOComplete();
        // 모든 트윈을 즉시 완료, 완료된 트윈의 개수를 반환 
    }

    public override void CreateFeedBack()
    {
        CompletePrevFeedBack();
        objectToShake.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
    }
}
