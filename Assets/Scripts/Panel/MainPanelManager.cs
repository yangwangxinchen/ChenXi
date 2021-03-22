using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
using UnityEngine.UI;
public class MainPanelManager : MonoBehaviour
{
    //行星UI面板
    //public GameObject planetUIPanel;
    //行星面板
    GameObject planetPanel;
    //转场视频
    public GameObject videoImage;
    //粒子
    public GameObject particleGo;
    public GameObject particleDoor;
    //黑屏过渡
    public Image blackImage;

    public GameObject bg;
  
    VideoPlayer player;

    public BoxCollider doorBox;

    //public  AudioSource mainSource;
    
    private void Awake()
    {
       
    }

    public void ShowHidePage(bool show)
    {
        particleGo.SetActive(show);
        bg.SetActive(show);
      
    }

    public void LoadVideo()
    {
        //暂停首页音乐
        ReadData.instance.mainAudioSource.Pause();

        videoImage.SetActive(true);
        particleGo.SetActive(false);

        player.Play();

    }

    void Start()
    {
        player = videoImage.GetComponent<VideoPlayer>();
        player.loopPointReached += VideoPlayer_loopPointReached;

        planetPanel = GameObject.FindGameObjectWithTag("planetPanel");
    }

    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        //播放完了
        VideoPlayFinished();
    }

    public void VideoPlayFinished()
    {
        //处理残帧
        //player.targetTexture.Release();
        videoImage.SetActive(false);
        doorBox.enabled = true;
        BgReset();
        //视频结束在过渡一次
        //blackImage.gameObject.SetActive(true);
        // blackImage.color = new Color(255, 255, 255, 1);
        // blackImage.DOFade(0, 2).SetEase(Ease.Linear).OnComplete(NextPanel);
        NextPanel();
    }

    public void NextPanel()
    {
        //显示行星ui面板
       // planetUIPanel.transform.GetChild(0).gameObject.SetActive(true);
        //显示行星 一级目录
        planetPanel.transform.GetChild(0).gameObject.SetActive(true);

        
        //播放一级目录音乐
        if (ReadData.instance.audioSource)
        {
            ReadData.instance.audioSource.Play();
        }
        
        //隐藏主面板  要放到最后
        gameObject.SetActive(false);
    }


    public void ClickDoor()
    {
        doorBox.enabled = false;
        //聚焦 bg缩放 上移 粒子播放 过渡
        //bg隐藏 粒子隐藏 播放视频
        //视频播放完成 过渡 跳转界面
        Focusing();
        
    }

    public void Focusing()
    {
        bg.transform.DOScale(new Vector3(4, 4, 1), 3).SetEase(Ease.Linear);
        bg.transform.DOLocalMoveY(-300, 3).SetEase(Ease.Linear).OnComplete(()=> {
            //DOFade();
            LoadVideo();
            SetVisibility();   
        });

        //显示门上的粒子
        particleDoor.SetActive(true);
        
    }

    //隐藏粒子
    public void SetVisibility()
    {      
        ////bg.SetActive(false);
        particleDoor.SetActive(false);
        particleGo.SetActive(false);    
    }

    public void BgReset()
    {
        //背景图位置 尺寸还原
        bg.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        // bg.transform.DOLocalMoveY(0, 0.1f).OnComplete(()=>LoadVideo());
        bg.transform.DOLocalMoveY(0, 0.1f);
    }


    //颜色渐变
    public void DOFade()
    { 
        blackImage.gameObject.SetActive(true);
        blackImage.color = new Color(255, 255, 255, 1);
        blackImage.DOFade(0, 2f).SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        //处理残帧
        player.targetTexture.Release();
    }
}
