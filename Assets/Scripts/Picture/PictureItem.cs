using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 单张图片的点击事件
/// </summary>
public class PictureItem : MonoBehaviour
{ 
    PressGesture pressGesture;
    public  UnityAction unityAction;

    bool isClick =false;
    float intervalTime;
    float desireTime = 1.5f;

    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;
    }

    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        if (isClick)
        {
            isClick = false;
            //if 隐藏物体
            transform.parent.gameObject.SetActive(false);
            //恢复点击区域的collider  
            ResetCollider();
        }       


    }

    public void ResetCollider()
    {
        if (unityAction!=null)
        {
            unityAction.Invoke();
        }
    }

    private void Update()
    {
        if (isClick == false)
        {
            intervalTime += Time.deltaTime;
            if (intervalTime >= desireTime)
            {
                isClick = true;
                intervalTime = 0;
            }
            //Debug.Log(intervalTime); 
        }
    }
}
