using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
using UnityEngine.Networking;

public class ReadData : MonoBehaviour
{

    public static ReadData instance;
    public InfoModel infoModel = new InfoModel();
    public VideoModel videoModel = new VideoModel();

    /// <summary>
    /// 一级目录音乐
    /// </summary>
    public AudioSource audioSource;
    /// <summary>
    /// 首页目录音乐
    /// </summary>
    public AudioSource mainAudioSource;
    //string path;
    //string mainAudioPath;

    private void Awake()
    {
        instance = this;
        ReadDataByModel();
    }
    private void Start()
    {
        Screen.SetResolution(2048, 768,true);

        StartCoroutine(LoadAudio("main", (o) => {
            mainAudioSource.clip = o;
            mainAudioSource.Play(); 
        }));

        StartCoroutine(LoadAudio("one", (o) => {
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

    IEnumerator LoadAudio(string soundName,System.Action<AudioClip> action)
    {
        string uri = Application.streamingAssetsPath+"/audio/" + soundName + ".wav";
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
                if (action!=null)
                {
                    action.Invoke(audioClip);
                }              
            }
        }
    }


    public void ReadDataByModel()
    {
        //infoModel = GetData<InfoModel>("info.json");
        videoModel = GetData<VideoModel>("videolist.json");
    }

    public T GetData<T>(string jsonName)
    {
        StreamReader streamreader = new StreamReader(Application.streamingAssetsPath + "/" + jsonName);//读取数据，转换成数据流
        JsonReader js = new JsonReader(streamreader);  //再转换成json数据
        return JsonMapper.ToObject<T>(js);    //返回数据模型
    }




}
