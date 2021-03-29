using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ServicePicMove : MonoBehaviour
{
    RectTransform board;
    [HideInInspector]
    public Image pic;

    [HideInInspector]
    public RectTransform picRect;

    //移动的起点
    Vector2 beginPos;
    public float beginPosY=-300;
   //初始位置
   Vector2 originPos;

    [HideInInspector]
    public ServicePicMove nextPic;
   
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        if (board == null)
        {        
            board = GetComponent<RectTransform>();
            originPos = board.anchoredPosition;
            pic = transform.GetChild(0).GetComponent<Image>();
            picRect = transform.GetChild(0).GetComponent<RectTransform>();
            SetBeginPostion();
            //Debug.Log("初始化——获取图片");
        }
    }

    void SetBeginPostion()
    {
        beginPos = new Vector2(originPos.x, beginPosY);
        board.anchoredPosition = beginPos;
    }

    public void TweenImage()
    {
        Init();
        board.DOAnchorPos(originPos, 1).OnComplete(NextTweenImage);
    }

    public void NextTweenImage()
    {
        if (nextPic!=null)
        {
            nextPic.TweenImage();
        }
    }

    /// <summary>
    /// 恢复默认状态
    /// </summary>
    public void ResetDefault()
    {
        Init();
        board.DOKill();
        SetBeginPostion();
    }


}
