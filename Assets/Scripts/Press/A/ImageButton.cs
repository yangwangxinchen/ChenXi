using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageButton : PressBase
{
    public Image image;
    GameObject window;
    public override void PressGesture_Pressed(object sender, EventArgs e)
    {
        base.PressGesture_Pressed(sender, e);
        PopVideo();
    }


    public void PopVideo()
    {
        if (window!=null)
        {
            window.SetActive(true);
        }
    }


    public void SetValue(string _picPath,GameObject _window)
    {
        Sprite sprite = ReadDataUtil.ReadPicture(_picPath);
        image.sprite = sprite;

        Vector2 picSize = new Vector2(sprite.texture.width * 0.6f, sprite.texture.height * 0.6f);
        //图片尺寸
        transform.GetComponent<RectTransform>().sizeDelta = picSize;
        //碰撞盒尺寸
        boxCollider.size = new Vector3(picSize.x, picSize.y, 10);

        window = _window;
    }

}
