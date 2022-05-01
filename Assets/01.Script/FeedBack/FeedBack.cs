using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeedBack : MonoBehaviour
{
    public abstract void CreateFeedBack(); // �ǵ�� ���
    public abstract void CompletePrevFeedBack(); // ���� �ǵ�� ����

    private void OnDestroy()
    {
        CompletePrevFeedBack();
    }

    private void OnDisable()
    {
        CompletePrevFeedBack();
    }
}
