using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoColor : MonoBehaviour
{
    Image image;
    Sequence sequence;
    [Header("需要渐变的文本")]
    public Text[] texts;


    private void Awake()
    {
        image = GetComponent<Image>();
        ResetState();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void PlayTextAnim()
    {
        sequence = DOTween.Sequence();
        //source.Play();

        if (texts!=null)
        {   
             for (int i = 0; i < texts.Length; i++)
             {
                    sequence.Append(texts[i].DOFade(1,1).SetEase(Ease.InExpo));

                    sequence.AppendInterval(0.2f);
             }                      
        }
    }

    private void OnEnable()
    {
        image.DOFade(1, 1.5f).SetEase(Ease.InExpo).OnComplete(PlayTextAnim);
    }

    private void OnDisable()
    {
        
        image.DOKill();
        sequence.Kill();
        ResetState();

    }

    public void ResetState()
    {
        image.color = new Color(255, 255, 255, 0);
        if (texts != null)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].color = new Color(255, 255, 255, 0);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
