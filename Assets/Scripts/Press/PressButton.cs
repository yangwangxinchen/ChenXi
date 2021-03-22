using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchScript.Gestures;

/// <summary>
/// 调节视频的按钮
/// </summary>
public class PressButton : MonoBehaviour
{
    public enum ButtonType
    {
        up,down,left,right,fullscreen,close,none
    }

    PressGesture pressGesture;
    public ButtonType buttonType=ButtonType.none;
    //视频贴图尺寸 视频贴图附加在里面
    GameObject videoSize;
    Vector2 videoImageMin;
    Vector2 videoImageMax;

    bool isFullScreen;

    public bool IsFullScreen { get => isFullScreen; set => isFullScreen = value; }

    float screenWidth = 2048;
    float screenHeight = 768;

    float canvasWidth = 1280;
    float canvasHeight;   //根据宽匹配调节高度

    float ratio;

    float offset = 2;

    EnterCXPlanel cxPanel;
    // Start is called before the first frame update
    void Start()
    {
        pressGesture = GetComponent<PressGesture>();
        pressGesture.Pressed += PressGesture_Pressed;

        //TODO 父物体
        //videoSize = transform.parent.parent.GetChild(0).gameObject;
        videoSize = transform.parent.parent.gameObject;

        //screenWidth = Screen.width;
        //screenHeight = Screen.height;
        ratio = screenWidth / canvasWidth;
        canvasHeight = screenHeight / ratio;


        if (ReadData.instance.audioSource)
        {
            //ReadData.instance.audioSource.Pause();
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDestroy()
    {
        if (ReadData.instance.audioSource)
        {
           // ReadData.instance.audioSource.Play();
        }

    }
    private void PressGesture_Pressed(object sender, System.EventArgs e)
    {
        OnButonClick();
    }

    public void OnButonClick()
    {
        switch (buttonType)
        {
            case ButtonType.up:
                if (isFullScreen) return;

                
                if (videoSize.transform.localPosition.y <=(canvasHeight / 2))
                {
                   // Debug.Log("上移");
                    videoSize.transform.position += new Vector3(0, offset, 0);
                }
                break;
            case ButtonType.down:

                if (isFullScreen) return;
                if (videoSize.transform.localPosition.y>=(-canvasHeight/ 2))
                {
                    videoSize.transform.position += new Vector3(0, -offset, 0);
                }
                break;
            case ButtonType.left:

                if (isFullScreen) return;
                if (videoSize.transform.localPosition.x >= (-canvasWidth / 2))
                {
                    videoSize.transform.position += new Vector3(-offset, 0, 0);
                }
                break;
            case ButtonType.right:

                if (isFullScreen) return;
                if (videoSize.transform.localPosition.x <= (canvasWidth / 2))
                {
                    videoSize.transform.position += new Vector3(offset, 0, 0);
                }
                break;
            case ButtonType.fullscreen:
                //需要锚点在四个角
                //videoSize.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                //videoSize.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                //锚点在中心
                videoSize.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                //videoSize.GetComponent<RectTransform>().offsetMin =new Vector2(10,10);
                videoSize.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,canvasWidth);
                // 5760/1280   4.5   canvas缩放比例 1200/4.5=266      设备分辨率/（canvas）预设分辨率   预览分辨率

                //设备分辨率/预设分辨率=比例   canvas高 =设备分辨率/比例  根据宽匹配  1080/ 1920/1280         
                videoSize.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,canvasHeight);

                //禁止移动视频
                //for (int i = 0; i < transform.parent.childCount; i++)
                //{
                //    transform.parent.GetChild(i).GetComponent<PressButton>().IsFullScreen = true;
                //}

                
                //显示全屏按钮组
                transform.parent.parent.GetChild(2).gameObject.SetActive(true);

                //启用父物体碰撞
                transform.parent.parent.parent.GetComponent<BoxCollider>().enabled = true;

                //隐藏正常按钮组
                transform.parent.gameObject.SetActive(false);
                

                break;

            case ButtonType.close:
                
                if (!cxPanel)
                {
                    //print("不在cxPanel");
                    cxPanel = FindObjectOfType<EnterCXPlanel>();
                }

                if (cxPanel!=null)
                {
                    //关掉企业宣传视频界面
                    //print("在cxPanel");
                    cxPanel.ClosePanel();

                }
                if (ReadData.instance.audioSource)
                {
                   // ReadData.instance.audioSource.Play();
                }
                
                //do  测试 
                // Destroy(transform.parent.parent.gameObject);

                //摧毁视频窗口
                Destroy(transform.parent.parent.parent.gameObject);

                break;
            case ButtonType.none:
                break;
            default:
                break;
        }
    }

}

