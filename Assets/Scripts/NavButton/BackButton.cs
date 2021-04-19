using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    //当前连触时间
    float intervalTime;
    //间隔时间
    float desireTime = 1f;
    //当前点击
    bool isClick;

    public  GameObject backPage;
    public GameObject currentPage;
    PressGesture pressGesture;
   

    //start 程序运行时并且处于可见状态运行
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

    }

    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        if (isClick)
        {
            backPage.SetActive(true);
            currentPage.SetActive(false);
            isClick = false;

        }
       
    }

    private void Update()
    {
        if (isClick==false)
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
