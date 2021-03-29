using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;


/// <summary>
/// 
/// </summary>
public class BackPlanetButton : MonoBehaviour
{
    public GameObject currentPage;
    GameObject planetPage;
    //行星ui面板
    GameObject planetUIPanel;
    PressGesture pressGesture;
   

    //start 程序运行时并且处于可见状态运行
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        //无法找到隐藏的物体
        planetPage = GameObject.FindGameObjectWithTag("planetPanel");
       // planetUIPanel=GameObject.FindGameObjectWithTag("planetUIPanel");
    }

   //注意 行星的两个面板父组件不要隐藏


    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        _aaaaaaaa();
    }

    public void _aaaaaaaa()
    {
        //回到星球目录
        planetPage.transform.GetChild(0).gameObject.SetActive(true);
        // planetUIPanel.transform.GetChild(0).gameObject.SetActive(true);
        //隐藏当前目录
        currentPage.SetActive(false);

    }
    
}
