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
    //snapping => ���� ���� ����
    //fadeOut => ���� �ڸ��� ���ư�

    public override void CompletePrevFeedBack()
    {
        objectToShake.transform.DOComplete();
        // ��� Ʈ���� ��� �Ϸ�, �Ϸ�� Ʈ���� ������ ��ȯ 
    }

    public override void CreateFeedBack()
    {
        CompletePrevFeedBack();
        objectToShake.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
    }
}
