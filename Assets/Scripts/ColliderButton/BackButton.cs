using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class BackButton : MonoBehaviour
{

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
        backPage.SetActive(true);
        currentPage.SetActive(false);
    }




}
