using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.UI;
using UnityEngine.Video;
/// <summary>
/// 这个其实是管理视频的按钮  点击相对应的产品后，实例化视频窗口
/// </summary>
public class ProductButton : MonoBehaviour
{

    public float width = 80;
    public float height = 80;
    public Vector2 videoPos;
    //与当前产品的父目录同级  这样就可以遮挡住「返回」按钮 
    public Transform videoWindowParent;

    [HideInInspector]
    public RectTransform rect;
    PressGesture pressGesture;
    public string videoName = "星际之缘/1";

    RenderTexture videotexture;
    public Vector2 ButtonPos = new Vector2(0, -76);
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        if (pressGesture == null)
        {
            pressGesture = gameObject.AddComponent<PressGesture>();
        }
        pressGesture.Pressed += PressGesture_Pressed;


        rect = GetComponent<RectTransform>();
    }
    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        //if (FindVideoPath() != null)
        //{
        //    LoadAndCreateVideo();
        //}

        LoadAndCreateVideo();
    }

    public string FindVideoPath()
    {
        //Debug.Log(ReadDataUtil.ReadMovePath(videoName));
        return ReadDataUtil.ReadMovePath(videoName);
    }

    /// <summary>
    /// 生成视频窗口
    /// </summary>
    public void LoadAndCreateVideo()
    {
        bool isFlag = false;

        for (int i = 0; i < videoWindowParent.childCount; i++)
        {

            if (videoWindowParent.GetChild(i).name == "VideoWindow" + gameObject.name)
            {
                //同一产品存在 跳出遍历
                isFlag = true;
                break;
            }
            else if (videoWindowParent.GetChild(i).name.Contains("VideoWindow"))
            {
                //删除掉之前的视频窗口
                DestroyImmediate(videoWindowParent.GetChild(i).gameObject);
            }
        }

        if (isFlag == false)  //不是同一产品
        {
            //生成视频对象
            GameObject videoWindowPrefab = Resources.Load<GameObject>("Prefabs/VideoWindow");

            // 创建临时贴图
            videotexture = RenderTexture.GetTemporary(1920, 1080);

            GameObject videoWindowGo = Instantiate(videoWindowPrefab, videoWindowParent);

            videoWindowGo.transform.GetChild(0).GetComponent<RawImage>().texture = videotexture;
            videoWindowGo.transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().targetTexture = videotexture;

            //视频 size 
            RectTransform rectTransform = videoWindowGo.transform.GetChild(0).GetComponent<RectTransform>();
            //视频按钮
            RectTransform rectButtons = videoWindowGo.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();

            rectTransform.anchoredPosition = videoPos;
            rectButtons.anchoredPosition = ButtonPos;

            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            videoWindowGo.name = "VideoWindow" + gameObject.name;

            //播放视频  视频名  对应路径
            if (FindVideoPath() != null)
            {
                videoWindowGo.transform.GetChild(0).GetChild(0).GetComponent<PlayVideo>().PrepareVideo(FindVideoPath());
                videoWindowGo.transform.GetChild(0).GetChild(0).GetComponent<PlayVideo>().SetVideoLoop(true);
            }

            //暂停背景音乐
            if (ReadData.instance.audioSource)
            {
                ReadData.instance.audioSource.Pause();
            }
        }
    }



    public void DestoryVideo()
    {
        bool isFlag = false;
        int flag = -1;
        for (int i = 0; i < videoWindowParent.childCount; i++)
        {
            if (videoWindowParent.GetChild(i).name.Contains("VideoWindow"))
            {
                isFlag = true;
                flag = i;
                break;
            }
        }

        if (isFlag)
        {
            //删除掉视频窗口
            Destroy(videoWindowParent.GetChild(flag).gameObject);
            RenderTexture.ReleaseTemporary(videotexture);
            videotexture = null;
        }

    }

    private void OnDisable()
    {
        DestoryVideo();

        //Debug.Log("摧毁视频");
    }

}

