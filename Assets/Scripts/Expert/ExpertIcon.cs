using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ExpertIcon : MonoBehaviour
{
    public Image image;
    public Text title;
    public Text subTitle;

    PressGesture pressGesture;
    RectTransform rect;
    bool isBig = false;

    GameObject blue;
    bool isLast;

 

    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;
        rect = GetComponent<RectTransform>();

        blue = transform.GetChild(1).gameObject;

        
    }

    //public bool IsLast
    //{
    //    get => isLast;

    //    set
    //    {
    //        isLast = value;
    //        if (isLast&& blue)
    //        {

    //            blue.SetActive(false);
    //        }
    //    }
    //}

    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        SetScale();
    }

    public void SetValue(string _spritePath,string _title,string _subtitle)
    {
        image.sprite = Resources.Load<Sprite>("expert/"+_spritePath);
        title.text = _title;
        subTitle.text = _subtitle;
        //if (int.Parse(_spritePath)==9)
        //{
        //    blue.SetActive(false);
        //}
    }

    public void SetScale()
    {
        if (isBig)
        {
            rect.DOScale(0.5f,1);
        }
        else
        {
            rect.DOScale(0.6f, 1);
        }
        isBig = !isBig;
    }

   
}
