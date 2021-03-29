using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单个ui移动
/// </summary>
public class SingleMove : MonoBehaviour
{
    RectTransform rect;
    Vector2 originPos;
    public float beginPosY = -300;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        originPos = rect.anchoredPosition;
        SetBeginPosition();
    }

    public void SetBeginPosition()
    {
        rect.anchoredPosition = new Vector2(originPos.x, beginPosY);
    }

    public void TweenMove()
    {
        rect.DOAnchorPos(originPos, 0.8f).OnComplete(TweenComplete);
    }

    public void TweenComplete()
    {
        //动画结束
    }

    public void ResetDefault()
    {
        rect.DOKill();
        SetBeginPosition();
    }

    private void OnEnable()
    {
        TweenMove();
    }
    private void OnDisable()
    {
        ResetDefault();
    }
}
