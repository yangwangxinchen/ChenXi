using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class PlanetItem : MonoBehaviour
{
    PressGesture pressGesture;
    //行星面板
    GameObject currentPanel;
    public GameObject toPanel;
    //行星ui面板
    GameObject planetUIPanel;
    public  string title;

    //start 程序运行时并且处于可见状态运行
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        //行星页面
        currentPanel = transform.parent.parent.gameObject;
        //对比父物体上的title
        //title = transform.parent.GetComponent<PlanetRotate>().title;

        //planetUIPanel = GameObject.FindGameObjectWithTag("planetUIPanel");
    }

    private void Update()
    {
       //transform.Rotate(transform.up, 10 * Time.deltaTime);
    }
    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        toPanel.SetActive(true);

        if (title == "走进晨曦")
        {
            Debug.Log("走进晨曦");
            PlayVideo();
        }

        //planetUIPanel.transform.GetChild(0).gameObject.SetActive(false);
        currentPanel.SetActive(false);
        

    }


        public void PlayVideo()
        {
            //生成视频对象
            GameObject videoWindowPrefab = Resources.Load<GameObject>("Prefabs/VideoWindow");
            GameObject videoWindowGo = Instantiate(videoWindowPrefab, toPanel.transform);
            RectTransform rectTransform = videoWindowGo.transform.GetChild(0).GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, 0);

        RectTransform rectbutton = videoWindowGo.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
        rectbutton.anchoredPosition = new Vector2(290,0);

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,400);
        //播放视频  视频名 保证第一个文件是企业宣传视频
        videoWindowGo.transform.GetChild(0).GetChild(0).GetComponent<PlayVideo>().PrepareVideo(
                ReadData.instance.videoModel.videolist[0].path);

            videoWindowGo.transform.GetChild(0).GetChild(0).GetComponent<PlayVideo>().SetVideoLoop(true);
            
    }

    } 
