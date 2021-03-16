using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;
public class CultureItem : MonoBehaviour
{

    public Image image;


    PressGesture pressGesture;

    Transform parent;
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        
    }

    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }

    public void SetValue(Sprite sprite)
    {
       image.sprite= sprite;
    }

}
