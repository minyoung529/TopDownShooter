using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FeedBack : MonoBehaviour
{
    public abstract void CreateFeedBack(); // 피드백 재생
    public abstract void CompletePrevFeedBack(); // 이전 피드백 종료

    private void OnDestroy()
    {
        CompletePrevFeedBack();
    }

    private void OnDisable()
    {
        CompletePrevFeedBack();
    }
}
