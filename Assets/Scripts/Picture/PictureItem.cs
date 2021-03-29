using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.Events;

public class PictureItem : MonoBehaviour
{ 
    PressGesture pressGesture;
    public  UnityAction unityAction;
   
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;
    }
    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        //if 隐藏物体
        transform.parent.gameObject.SetActive(false);
        //if 放大缩小  

        ResetCollider();
    }

    public void ResetCollider()
    {
        if (unityAction!=null)
        {
            unityAction.Invoke();
        }
    }
}
