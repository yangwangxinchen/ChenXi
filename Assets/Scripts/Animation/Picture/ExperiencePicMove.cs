using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;


public class ExperiencePicMove : MonoBehaviour
{
    RectTransform title;
    RectTransform introduce;
    Vector2 titleOriginPos;
    Vector2 introduceOriginPos;
    float moveTime = 1;
    Image arrowImage;
    [HideInInspector]
    public ExperiencePicMove nextPicMove;

    private void Awake()
    {
        title= transform.GetChild(0).GetComponent<RectTransform>();
        introduce = transform.GetChild(1).GetComponent<RectTransform>();
        arrowImage = transform.GetChild(2).GetComponent<Image>();
        titleOriginPos = title.anchoredPosition;
        introduceOriginPos = introduce.anchoredPosition;
        Init();
    }
    private void Init()
    {
        //line.SetActive(false);
        arrowImage.color=new Color (255,255,255,0);
        SetBeginPostion();
    }

    void SetBeginPostion()
    {
        title.anchoredPosition = new Vector2(titleOriginPos.x, -400);
        introduce.anchoredPosition = new Vector2(introduceOriginPos.x, -400);
    }
    public void PicMoveY()
    {
        title.DOAnchorPos(titleOriginPos, moveTime).OnComplete(() =>
        {
            introduce.DOAnchorPos(introduceOriginPos, moveTime).OnComplete(()=>{

                NextPicMove();

            });
        });

    }

    public void NextPicMove()
    {
        if (nextPicMove!=null)
        {
            //箭头显示
            nextPicMove.arrowImage.DOFade(1, 1);
            //位置移动
            nextPicMove.PicMoveY();
        }
    }

    public void ResetDefault()
    {
        Init();
        title.DOKill();
        introduce.DOKill();
        arrowImage.DOKill();
    }


    private void OnEnable()
    {
        //PicMoveY();
    }

    private void OnDisable()
    {
        //ResetDefault();
    }
}
