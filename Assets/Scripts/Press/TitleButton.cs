using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using DG.Tweening;
using UnityEngine.UI;
using System.IO;

public class TitleButton : MonoBehaviour
{
    PressGesture pressGesture;

    Transform parent;
    GameObject tempGo;
  
    Sprite sprite;

    public string picName;
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        parent = transform.parent.parent.GetComponent<Transform>();
    }

    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        //Debug.Log("弹出图片");
        CreateTexture();
    }

    public void CreateTexture()
    {
       GameObject tempPrefab= Resources.Load<GameObject>("culture/cultureImage");

        string picPath = Application.streamingAssetsPath + "/culture/" + picName+".jpg";
        if (File.Exists(picPath))
        {
           byte[] picBytes =File.ReadAllBytes(picPath);
            Texture2D texture2D = new Texture2D(128,128);
            texture2D.LoadImage(picBytes);
            sprite= Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one / 2f);
        
        }
        
        tempGo =Instantiate(tempPrefab, parent);
        tempGo.transform.DOScale(0,0.1f);
        if (picName == "2")    //晨曦之为
        {
            //Debug.Log(tempGo.transform.localPosition);
            tempGo.transform.localPosition = new Vector3(-297f, 0f, 0);
        }

        tempGo.GetComponent<CultureItem>().SetValue(sprite);

       tempGo.transform.DOScale(2.5f, 2);
    }

    private void OnDisable()
    {
        if (tempGo!=null)
        {
            Destroy(tempGo);
        }
    }

}
