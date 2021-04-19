using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlanePicMove : MonoBehaviour
{
    public RectTransform info;
    public RectTransform title;
    public RectTransform star;

    Vector2 infoOriginPos;
    Vector2 titleOriginPos;
    Vector2 starOriginPos;

    [HideInInspector] public PlanePicMove next;

    private void Awake()
    {
        infoOriginPos = info.anchoredPosition;
        titleOriginPos = title.anchoredPosition;
        starOriginPos = star.anchoredPosition;
        SetBeginPosition();
    }

    public void SetBeginPosition()
    {
        info.anchoredPosition = new Vector2(infoOriginPos.x, -500);
        title.anchoredPosition = new Vector2(titleOriginPos.x, -500);
        star.anchoredPosition = new Vector2(starOriginPos.x, -500);
    }

    public void TweenMove()
    {
        //1.星星移动
        star.DOAnchorPos(starOriginPos,0.8f).OnComplete(() =>
           {
               //2.下方信息移动
               title.DOAnchorPos(titleOriginPos,0.8f).OnComplete(() => 
               {
                   //3.上方信息移动
                   info.DOAnchorPos(infoOriginPos, 1).OnComplete(()=>
                   {
                       if (next!=null)
                       {
                           next.TweenMove();
                       }
                   });
                              
               });
           }

    );
    }

    public void ResetDefault()
    {
        star.DOKill();
        info.DOKill();
        title.DOKill();
        SetBeginPosition();
    }

    private void OnEnable()
    {  
        //TweenMove();
    }

    private void OnDisable()
    {
        //ResetDefault();
    }
}
