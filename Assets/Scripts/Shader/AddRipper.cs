//点击鼠标产生波纹
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript;
using TouchScript.Pointers;

public class AddRipper : MonoBehaviour
{
    public Camera mainCamera;
    public Shader shader;

    TouchManager _TM;

    //AudioSource audio;

    private void Start()
    {
        TouchManager.Instance.PointersPressed += Instance_PointersPressed;

        //audio = GetComponent<AudioSource>();
    }

    private void Instance_PointersPressed(object sender, PointerEventArgs e)
    {
        
        //主摄像机添加屏幕后处理脚本
        mainCamera.gameObject.AddComponent<RipperPostEffect>();
        RipperPostEffect[] components = mainCamera.gameObject.GetComponents<RipperPostEffect>();
        List<Pointer> _points= (List<Pointer>)TouchManager.Instance.Pointers;
        for (int i = 0; i < _points.Count; i++)
        {
            //指定shader
            components[components.Length - 1].shader = shader;
            //设置鼠标位置在（0，1）区间
            components[components.Length - 1].startPos = new Vector4(_points[i].Position.x / Screen.width, _points[i].Position.y / Screen.height, 0, 0);

            //点击声音
            //audio.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //主摄像机添加屏幕后处理脚本
        //    mainCamera.gameObject.AddComponent<RipperPostEffect>();
        //    RipperPostEffect[] components = mainCamera.gameObject.GetComponents<RipperPostEffect>();
        //    //指定shader
        //    components[components.Length - 1].shader = shader;
        //    //设置鼠标位置在（0，1）区间
        //    components[components.Length - 1].startPos = new Vector4(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0, 0);
        //}
    }
}

