using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    [SerializeField] private Button openBtn;
    [SerializeField] private Button closeBtn;

    private CanvasGroup canvasGroup;
    private RectTransform rect;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rect = GetComponent<RectTransform>();
    }

    void Start()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        rect.localScale = Vector3.zero;

        openBtn.onClick.AddListener(() =>
        {
            closeBtn.enabled = false;
            Sequence seq = DOTween.Sequence();

            // DOTween.To(get, set, end, time)
            DOTween.To(() => canvasGroup.alpha, v => canvasGroup.alpha = v, 1f, 0.8f);
            seq.Join(rect.DOScale(1f, 0.8f));
            seq.AppendCallback(() => closeBtn.enabled = true);
        });

        Sequence seq;
        closeBtn.onClick.AddListener(() =>
        {
            seq = DOTween.Sequence();
            DOTween.To(() => canvasGroup.alpha, v => canvasGroup.alpha = v, 0f, 0.8f);
            seq.Join(rect.DOScale(0f, 0.8f));
        });
    }

    void Update()
    {

    }
}
