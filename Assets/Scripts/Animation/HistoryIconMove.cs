using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// 历史进程图标动画
/// </summary>
public class HistoryIconMove : MonoBehaviour
{
    
    public float duration_text=1;
    public float duration_icon = 1;
    public Vector2 endValue_text;
    public Vector2 endValue_icon;

    Vector2 textOrigin;
    Vector2 iconOrigin;
    public  RectTransform rectTransform_text;
    public RectTransform rectTransform_icon;
    // Start is called before the first frame update
    void Start()
    {
        //BeginMove();
    }
    private void Awake()
    {
        textOrigin = rectTransform_text.anchoredPosition;
        iconOrigin = rectTransform_icon.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        BeginMove();
    }

    private void OnDisable()
    {
        rectTransform_icon.DOKill();
        rectTransform_text.DOKill();
        ResetTransform();
    }
    public void BeginMove()
    {
        rectTransform_icon.DOAnchorPos(endValue_icon, duration_icon).OnComplete(TextMove);
       
    }

    public void TextMove()
    {
        rectTransform_text.DOAnchorPos(endValue_text, duration_text);
    }

    public void ResetTransform()
    {
        rectTransform_text.anchoredPosition=textOrigin;
        rectTransform_icon.anchoredPosition=iconOrigin;

    }



}
