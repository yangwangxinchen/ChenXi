using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    //public GameObject startMovie;
    VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        //PrepareVideo("movie01.mov");
        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;

        
        if (ReadData.instance.audioSource != null)
        {
            ReadData.instance.audioSource.Pause();
        }
    }

    public void SetVideoLoop(bool isLoop)
    {
        videoPlayer.isLooping = isLoop;
    }

    /// <summary>
    /// 视频缓冲  
    /// </summary>
    /// <param name="videoName">视频相对于【视频】文件夹下的相对路径</param>
    public void PrepareVideo(string filePath)
    {
        //视频文件路径
        //string url = "file:///" + Application.dataPath + "/Movies/movie01.mov";
   
        if (filePath!=null)
        {
            //路径赋值
            videoPlayer.url = "file:///" + filePath;
            StartCoroutine(DelayPlayVideo());
        }
        else
        {
            //未找到路径
        }
       
    }
    IEnumerator DelayPlayVideo()
    {
        //启动播放引擎准备
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            //Debug.Log("准备中，视频加载中...");
            yield return null;
        }
        //播放视频
        videoPlayer.Play();
    }

    private void OnDestroy()
    {       
        if (ReadData.instance.audioSource!=null)
        {
            ReadData.instance.audioSource.Play();
        }
    }

}
