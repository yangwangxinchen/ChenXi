using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using DG.Tweening;
using UnityEngine.UI;


//public delegate void PressDoorDelegate();
public class PressDoor : MonoBehaviour
{
    PressGesture pressGesture;

    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;
    }

    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        transform.parent.transform.GetComponent<MainPanelManager>().ClickDoor();
    }

}
