using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheGreatGGM;
using DG.Tweening;

public class TestObj : MonoBehaviour
{
    Vector3 mousePos = Vector2.zero;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Define.MainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            DotweenTest();
        }

    }

    private void ExtensionMethodTest()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(x, y) * 3f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(transform.GGM());
        }
    }

    private void NoneDotweenTest()
    {
        transform.position = Vector2.MoveTowards(transform.position, mousePos, Time.deltaTime * 3f);
    }

    private void DotweenTest()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMove(mousePos, (transform.position - mousePos).magnitude / 2f));
        seq.Append(transform.DORotate(new Vector3(0, 0, 720f), 0.8f, RotateMode.FastBeyond360));
        seq.AppendCallback(() => Debug.Log("Tween ¡æ∑·")); // ≈¨∑Œ¡Æ (closure) ∆Ûº‚
    }
}
