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
        GameObject tempPrefab = Resources.Load<GameObject>("culture/cultureImage");
        Sprite sprite = ReadDataUtil.ReadPicture(picName);
        tempGo = Instantiate(tempPrefab, parent);
        tempGo.GetComponent<CultureItem>().SetValue(sprite);
        tempGo.transform.DOScale(0.5f, 1).From();
    }

    private void OnDisable()
    {
        if (tempGo != null)
        {
            Destroy(tempGo);
        }
    }

}
