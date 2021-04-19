using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class BackMainButton : MonoBehaviour
{
    public GameObject backPage;
    public GameObject currentPage;
    GameObject contentPanel;

    PressGesture pressGesture;


    //start 程序运行时并且处于可见状态运行
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;
        contentPanel = GameObject.FindGameObjectWithTag("planetPanel");
    }

    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        //主页显示
        backPage.SetActive(true);
        ReadData.instance.mainAudioSource.Play();

        backPage.GetComponent<MainPanelManager>().ShowHidePage(true);

        //一级目录音乐暂停
        ReadData.instance.audioSource.Pause();

        //一级目录 子页面隐藏
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);

        currentPage.SetActive(false);
    }

}
