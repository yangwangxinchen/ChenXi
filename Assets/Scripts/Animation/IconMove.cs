using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


/// <summary>
/// 核心品牌图标动画
/// </summary>
public class IconMove : MonoBehaviour
{
    public float duration;
    public  Vector2 endValue;
    public bool isDoScale;
    public float scaleFactor=0.8f;
    RectTransform rect;
    Vector2 originRectAnchoredPos;
    Tweener tweener;

    Vector3 originLocalScale;

    //AudioSource source;
    private void Awake()
    {
        //source = gameObject.AddComponent<AudioSource>();
        //source.clip = Resources.Load<AudioClip>("粒子音效");
        //source.playOnAwake = false;

        rect = GetComponent<RectTransform>();
        originRectAnchoredPos = rect.anchoredPosition;
        originLocalScale = rect.localScale;
    }

    private void Start()
    {
        //BeginMove();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginMove()
    {
        rect.DOAnchorPos(endValue, duration).SetEase(Ease.OutQuad).OnComplete(()=> { 
            if (isDoScale) IconScaleAnim();
            //source.Play();
        });

    }

    public void IconScaleAnim()
    {
        tweener = rect.DOScale(scaleFactor,1);
        tweener.SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);

    }

    public void KillMove()
    {
        rect.DOKill();
        if (tweener!=null)
        {
            tweener.Kill();
        }   
    }

    private void OnEnable()
    {
        BeginMove();
    }
    private void OnDisable()
    {
        KillMove();
        rect.anchoredPosition = originRectAnchoredPos;
        rect.localScale = originLocalScale;
    }

}
