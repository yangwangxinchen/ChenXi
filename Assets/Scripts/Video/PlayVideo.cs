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

    public void PrepareVideo(string videoName)
    {
        //视频文件路径
        //string url = "file:///" + Application.dataPath + "/Movies/movie01.mov";
        if (string.IsNullOrEmpty(videoName))
        {
            Debug.Log("找不到视频文件！");
            return;
        }

        string filePath= Application.streamingAssetsPath + "/Movies/" + videoName;
        if (File.Exists(filePath))
        {
            videoPlayer.url = "file:///" + filePath;
            StartCoroutine(DelayPlayVideo());
        }
        else
        {
            Debug.Log("找不到视频文件！");
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
        //Debug.Log("准备完毕");
        //videoPlayer.targetTexture.Release();
        videoPlayer.Play();
    }

    private void OnDestroy()
    {
        
        if (ReadData.instance.audioSource!=null)
        {
            ReadData.instance.audioSource.Play();
        }
    }

    private void OnDisable()
    {
        
    }
}
