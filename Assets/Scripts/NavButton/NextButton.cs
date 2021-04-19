using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    //public GameObject  nextPage;
    //public GameObject currentPage;

    public GameObject[] productPages;


    PressGesture pressGesture;

    int index=0;
    //start 程序运行时并且处于可见状态运行
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;
           
    }

    //设置页面显示
    public void SetPageActive(int currentPage)
    {
        if (productPages.Length==0)
        {
            return;
        }
        for (int i = 0; i < productPages.Length; i++)
        {
            productPages[i].SetActive(false);
        }

        productPages[currentPage].SetActive(true);
    }

    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        if (isClick)
        {
            ChangePage();
            isClick = false;
        }
        
    }

    public void ChangePage()
    {
        index++;
        if (index>=productPages.Length)
        {
            index = 0;
        }
        SetPageActive(index);      
    }

    private void OnEnable()
    {
        index = 0;
        SetPageActive(0);
    }

    bool isClick;
    float intervalTime;
    float desireTime = 1f;
    private void Update()
    {
        if (isClick == false)
        {
            intervalTime += Time.deltaTime;
            if (intervalTime >= desireTime)
            {
                isClick = true;
                intervalTime = 0;
            }
        }

    }
}
