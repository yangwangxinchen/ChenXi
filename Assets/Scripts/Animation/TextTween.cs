using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextTween : MonoBehaviour
{
    public Text[] texts;
    string[] infos;
    public float [] durationTimes;
    public int infolistIndex;
    public int contentIndex;

    Sequence sequence;
    //AudioSource source;

    private void OnEnable()
    {
        if (infos!=null)
        {
            BeginDoText();
        }
    }

    private void OnDisable()
    {
        ResetState();
    }

    void Start()
    {
        //记得手动清除掉text中的内容
        //写在start中 是为了防止（ReadData）数据读取不到

        //source = GetComponent<AudioSource>();
        //if (source==null)
        //{
        //    source = gameObject.AddComponent<AudioSource>();
        //    source.clip = Resources.Load<AudioClip>("打字声");
        //    source.playOnAwake = false;
        //    source.loop = true;
        //}

        infos = ReadData.instance.infoModel.infolist[infolistIndex].content[contentIndex].ToArray();

        //infos = ContentListModel.contentModels[0].contents;
        //第一次主动调用
        //Debug.Log("第一次主动调用");
        BeginDoText();
    }


    //开始文本动画    do: 利用序列器中的间隔插入改等待时间问题  参照
    public void BeginDoText()
    {
        PlayTextAnim();
        
    }

    //结束文本动画
    public void ResetState()
    {
        sequence.Kill();
        
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].DOKill();
            texts[i].text = "";   
        }
    }

    public void PlayTextAnim()
    {
        if (texts != null)
        {
           sequence= DOTween.Sequence();
            sequence.OnComplete(() =>
            {
                //Debug.Log("结束");
            });
            for (int i = 0; i < texts.Length; i++)
            {
                sequence.Append(
                    texts[i].DOText(infos[i], durationTimes[i]).SetEase(Ease.Linear)
                    ) ;
                
                if (i== texts.Length-1)
                {
                    break;
                }
                
                sequence.AppendInterval(durationTimes[i]);
            }
        }

    }

    
}
