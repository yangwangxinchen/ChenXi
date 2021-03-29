using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;
using UnityEngine.UI;
using System.IO;
using DG.Tweening;

/// <summary>
/// 点击某一区域（如文本）处。弹出指定图片文件
/// </summary>
public class ClickTextPopImage : MonoBehaviour
{
    PressGesture pressGesture;
    public string picPath;
    public Transform parent;
    public Vector2 picSize = new Vector2(200, 200);
    GameObject go=null;


    //子物体与父物体同时存在collider时 会忽略掉子物体的collider
    BoxCollider myCollider;
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        myCollider = GetComponent<BoxCollider>();
    }

    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        PopImage();
        //Debug.Log("弹出图片");
    }
    Transform productPicTransform;
    void CreateImage()
    {
        //图片/xx/xx /xx.jpg
        Sprite sprite = ReadDataUtil.ReadPicture(picPath);
        go = Instantiate(Resources.Load<GameObject>("productPic"));
        go.transform.SetParent(parent);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        //给图片预设物传值
        productPicTransform = go.transform.GetChild(0);
        productPicTransform = go.transform.GetChild(0);
        productPicTransform.GetComponent<Image>().sprite = sprite;
        productPicTransform.GetComponent<RectTransform>().sizeDelta = picSize;
        productPicTransform.GetComponent<BoxCollider>().size = new Vector3(picSize.x, picSize.y,10);
        //让图片能够点击
        PictureItem pictureItem= productPicTransform.gameObject.AddComponent<PictureItem>();
        //图片隐藏时 恢复自己的碰撞
        pictureItem.unityAction = ResetCollider;

    }

    //恢复碰撞
    public void ResetCollider()
    {
        myCollider.enabled = true;
    }
    void PopImage()
    {
        if (go!=null)
        {
            go.SetActive(true);
        }
        else
        {
            CreateImage();
        }

        productPicTransform.DOScale(0.2f, 1).From();
        myCollider.enabled = false;      
    }

    private void OnDisable()
    {
        if (go!=null)
        {
            productPicTransform.DOKill();
            go.SetActive(false);
            myCollider.enabled = true;
        }
    }
}
