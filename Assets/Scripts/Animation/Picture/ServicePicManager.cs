using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 服务机构动画
/// </summary>
public class ServicePicManager : MonoBehaviour
{
    public string picDir;
    List<ServicePicMove> servicePicMoves = new List<ServicePicMove>();
    private void Awake()
    {
        //添加
        for (int i = 0; i < transform.childCount; i++)
        {
            servicePicMoves.Add(transform.GetChild(i).GetComponent<ServicePicMove>());
        }

        //赋值
        for (int i = 0; i < servicePicMoves.Count; i++)
        {
            if (i != servicePicMoves.Count - 1)
            {
                servicePicMoves[i].nextPic = servicePicMoves[i + 1];
            }
           
        }
    }

    private void Start()
    {
        //传值 需要写在start中  保证servicePicMoves[i].pic不为空
        List<string> picNames = ReadDataUtil.ReadPictureContent(picDir);
        for (int i = 0; i < servicePicMoves.Count; i++)
        {
            Sprite sprite = ReadDataUtil.ReadPicture(picDir + "/" + picNames[i]);

            if (servicePicMoves[i].pic!=null)
            {
                servicePicMoves[i].pic.sprite = sprite;
                servicePicMoves[i].picRect.sizeDelta = new Vector2(sprite.texture.width*0.6f, sprite.texture.height*0.6f);
            }
            else
            {
                Debug.Log("图片未获取");
            }
            
        }

        servicePicMoves[0].TweenImage();
    }
    private void OnEnable()
    {
        servicePicMoves[0].TweenImage();
    }

    private void OnDisable()
    {
        for (int i = 0; i < servicePicMoves.Count; i++)
        {

            servicePicMoves[i].ResetDefault();

        }
    }
}
