using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackPlayer : MonoBehaviour
{
    [SerializeField] List<FeedBack> feedBacksToPlay = new List<FeedBack>();

    public void PlayFeedBack()
    {
        FinishFeedBack();

        foreach (FeedBack f in feedBacksToPlay)
        {
            f.CreateFeedBack();
        }
    }

    private void FinishFeedBack()
    {
        foreach (FeedBack f in feedBacksToPlay)
        {
            f.CompletePrevFeedBack();
        }
    }
}
