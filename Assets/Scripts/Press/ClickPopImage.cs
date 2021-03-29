using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;
using UnityEngine.UI;
using System.IO;
using DG.Tweening;

/// <summary>
/// 点击弹出图片
/// </summary>
public class ClickPopImage : MonoBehaviour
{
    PressGesture pressGesture;
    [Header("图片在streamingasset/图片/下的文件目录")]
    public string picDir;
    public Transform parent;

    [HideInInspector]
    public Vector2 picSize = new Vector2(200, 200);

    //只允许响应一次点击
    bool clickOnce = true;
    //[Tooltip("是否允许点击图片,默认不允许")]   //如果允许记得调整boxcollider的尺寸
    //public bool canClickPic = false;

    List<string> picNameAndExtensionList = new List<string>();
    List<GameObject> picGoList = new List<GameObject>();
    List<Transform> picRectList = new List<Transform>();
    //是否自动弹出图片
    public bool isAutoPop;

    GameObject tipText;
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        tipText = transform.GetChild(0).gameObject;
        GetImage();
        AutoPopImage();
    }

    private void PressGesture_Pressed(object sender, EventArgs e)
    {
        //Debug.Log("弹出图片");
        PopImage();
    }

    //读取文件夹下的图片
    public void GetImage()
    {
        picNameAndExtensionList = ReadDataUtil.ReadPictureContent(picDir);
    }

    //将读取的图片实例化出来
    public void CreateImage()
    {
        if (picNameAndExtensionList.Count == 0) 
        {
            tipText.SetActive(true);
            return;
        } 

        for (int i = 0; i < picNameAndExtensionList.Count; i++)
        {
            //图片/xx/xx /xx.jpg
            Sprite sprite = ReadDataUtil.ReadPicture(picDir + "/" + picNameAndExtensionList[i]);
            GameObject go = ReadData.instance.LoadResourcesAsset("productPic");
            go.transform.SetParent(parent);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            //给图片预设物传值
            Transform productPicTransform = go.transform.GetChild(0);
            productPicTransform = go.transform.GetChild(0);
            productPicTransform.GetComponent<Image>().sprite = sprite;         
            picSize = new Vector2(sprite.texture.width * 0.6f, sprite.texture.height * 0.6f);
            //钳制图片的尺寸
            picSize.x = Mathf.Clamp(picSize.x, 80, 300);
            picSize.y = Mathf.Clamp(picSize.y, 80, 300);
            productPicTransform.GetComponent<RectTransform>().sizeDelta = picSize;
           
            picRectList.Add(productPicTransform);
            picGoList.Add(go);
        }
    }

    /// <summary>
    /// 图片缩放动画
    /// </summary>
    /// <param name="isOpenTween"></param>
    public void TweenImage(bool isOpenTween)
    {
        if (isOpenTween)
        {
            for (int i = 0; i < picRectList.Count; i++)
            {
                picRectList[i].DOScale(0.2f, 1).From();
            }
        }
        else
        {
            for (int i = 0; i < picRectList.Count; i++)
            {
                picRectList[i].DOKill();
            }
        }
    }

    /// <summary>
    /// 自动生成图片
    /// </summary>
    public void AutoPopImage()
    {
        if (isAutoPop)
        {
            transform.GetComponent<BoxCollider>().enabled = false;

            CreateImage();
        }
    }

    /// <summary>
    /// 弹出图片
    /// </summary>
    public void PopImage()
    {
        if (clickOnce)
        {
            if (picGoList.Count > 0)
            {
                for (int i = 0; i < picGoList.Count; i++)
                {
                    picGoList[i].SetActive(true);
                }
            }
            else
            {
                CreateImage();
            }
            TweenImage(true);
            clickOnce = false;
        }

    }

    private void OnDisable()
    {
        if (picGoList.Count > 0 && isAutoPop==false)
        {
            TweenImage(false);
            for (int i = 0; i < picGoList.Count; i++)
            {
                picGoList[i].SetActive(false);
            }
        }

        if (tipText!=null)
        {
            tipText.SetActive(false);
        }
        
    }

    private void OnEnable()
    {
        clickOnce = true;
    }



}
