using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 管理全局音频的脚本
/// </summary>
public class ReadData : MonoBehaviour
{
    public static ReadData instance;

    /// <summary>
    /// 一级目录音乐
    /// </summary>
    public AudioSource audioSource;
    /// <summary>
    /// 首页目录音乐
    /// </summary>
    public AudioSource mainAudioSource;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        StartCoroutine(LoadAudio("main", (o) =>
        {
            mainAudioSource.clip = o;
            if (mainAudioSource.gameObject.activeSelf)
            {
                mainAudioSource.Play();
            }
        }));

        StartCoroutine(LoadAudio("one", (o) =>
        {
            audioSource.clip = o;
        }));
    }


    /* IEnumerator LoadAudio()
     {
         WWW mainW = new WWW(mainAudioPath);
         while (!mainW.isDone)
         {
             yield return null;
         }
         AudioClip mainAC = mainW.GetAudioClip(true, true);
         mainAudioSource.clip = mainAC;
         mainAudioSource.Play();

         WWW www = new WWW(path);
         while (!www.isDone)
         {
             yield return null;
         }
         AudioClip ac = www.GetAudioClip(true, true);
         audioSource.clip = ac;
     }
 */

    IEnumerator LoadAudio(string soundName, System.Action<AudioClip> action)
    {
        string uri = Application.streamingAssetsPath + "/音频/" + soundName + ".wav";
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.WAV))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                AudioClip audioClip = DownloadHandlerAudioClip.GetContent(request);
                if (action != null)
                {
                    action.Invoke(audioClip);
                }
            }
        }
    }

}
