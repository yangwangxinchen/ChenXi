using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;


/// <summary>
/// 界面导航按钮
/// </summary>
public class NavButton : MonoBehaviour
{
    public GameObject navPage;
    
    public GameObject currentPage;

    [Header("需要隐藏的子界面")]
    public GameObject navSubHidePage;
    [Header("需要显示的子界面")]
    public GameObject navSubShowPage;

    PressGesture pressGesture;


    //start 程序运行时并且处于可见状态运行
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

    }

    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        navPage.SetActive(true);

        SetDefaultState();

        currentPage.SetActive(false);
    }

    public void SetDefaultState()
    {
        if (navSubShowPage!=null)
        {
            //保证当前页之前处于关闭状态
            navSubShowPage.SetActive(false);
            navSubShowPage.SetActive(true);
        }
        if (navSubHidePage != null)
        {
            navSubHidePage.SetActive(false);
        }
    }

}
