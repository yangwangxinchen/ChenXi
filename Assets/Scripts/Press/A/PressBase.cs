using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(PressGesture))]
public class PressBase : MonoBehaviour
{
    PressGesture pressGesture;
    public BoxCollider boxCollider;

    private void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        //boxCollider = GetComponent<BoxCollider>();
    }
    public virtual void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        Debug.Log("点击");
    }



}
