using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DoFade : MonoBehaviour
{
    Text text;
    //AudioSource source;
    private void Awake()
    {
        //if (source == null)
        //{
        //    source = gameObject.AddComponent<AudioSource>();
        //    source.clip = Resources.Load<AudioClip>("粒子音效");
        //    source.playOnAwake = false;

        //}
        text = GetComponent<Text>();
        ResetState();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetState()
    {
        text.color = new Color(255, 255, 255, 0);
    }
    private void OnEnable()
    {
        text.DOFade(1, 2f).SetEase(Ease.Linear);
        //source.Play();
    }

    private void OnDisable()
    {
        text.DOKill();
        ResetState();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
