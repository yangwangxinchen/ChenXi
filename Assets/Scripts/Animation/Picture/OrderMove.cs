using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 按顺序移动ui
/// </summary>
public class OrderMove : MonoBehaviour
{
    RectTransform rect;
    Vector2 originPos;

    public float beginPosY = -300;

    [HideInInspector] public OrderMove next;

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
        rect.DOAnchorPos(originPos, 0.8f).OnComplete(()=> {
            if (next!=null)
            {
                next.TweenMove();
            }
            
        });
    }

    public void ResetDefault()
    {
        rect.DOKill();
        SetBeginPosition();
    }

    private void OnEnable()
    {
        //TweenMove();
    }
    private void OnDisable()
    {
        //rect.DOKill();
    }
}
