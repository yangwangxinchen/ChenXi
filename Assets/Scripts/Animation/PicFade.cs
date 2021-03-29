using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制图片的显示  需要image为filled填充模式
/// </summary>
public class PicFade : MonoBehaviour
{
    bool isEnable;
    public Image image;
    float timer = 0;
    public float desireTime = 2;
    private void Update()
    {
        if (isEnable)
        {
            timer += Time.deltaTime;
            image.fillAmount = timer / desireTime;
            if (timer>= desireTime)
            {
                isEnable = false;
                timer = 0;
            }
        }
    }
    private void OnEnable()
    {
        isEnable = true;
    }

   
}
