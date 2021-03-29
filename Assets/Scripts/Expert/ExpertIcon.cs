using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
public class ExpertIcon : MonoBehaviour
{
    public Image image;
    public Text title;
    public Text subTitle;

    PressGesture pressGesture;
    RectTransform rect;
    bool isBig = false;
    /// <summary>
    /// 蓝色线条
    /// </summary>
    [HideInInspector]public GameObject blue;

 

    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;
        rect = GetComponent<RectTransform>();      
    }

    public void HideBlue()
    {
        blue = transform.GetChild(1).gameObject;
        blue.SetActive(false);
    }
    

    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        SetScale();
    }

    /// <summary>
    /// 给图片预设物赋值
    /// </summary>
    /// <param name="_spritePath">专家图片路径</param>
    /// <param name="_title">专家名</param>
    /// <param name="_subtitle">专家介绍</param>
    public void SetValue(string _spritePath,string _title,string _subtitle)
    {
        image.sprite = Resources.Load<Sprite>("expert/"+_spritePath);
        title.text = _title;
        subTitle.text = _subtitle;
        //if (int.Parse(_spritePath)==9)
        //{
        //    blue.SetActive(false);
        //}
    }

    /// <summary>
    /// 对图片进行放大缩小
    /// </summary>
    public void SetScale()
    {
        if (isBig)
        {
            rect.DOScale(0.5f,1);
        }
        else
        {
            rect.DOScale(0.6f, 1);
        }
        isBig = !isBig;
    }

   
}
