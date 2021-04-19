using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WindowManager : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetValue(string videoPath)
    {
        RenderTexture texture= RenderTexture.GetTemporary(2048,768);
        videoPlayer.url = "file:///" + videoPath;
        videoPlayer.targetTexture = texture;
        rawImage.texture = texture;
        //RenderTexture.ReleaseTemporary(texture);
    }
    
    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
