using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageButtonManager : MonoBehaviour
{
    public int imageCount=1;
    public string picDir;
    public string videoDir;
    public Transform grid;
    public void InitProduct()
    {
        List<string> picNames=ReadDataUtil.ReadPictureContent(picDir);
        List<string> videoNames = ReadDataUtil.ReadMoveContent(videoDir);
        //Debug.Log(picNames[0]);
        for (int i = 0; i < imageCount; i++)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("productImage"));
            go.transform.SetParent(grid);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            ImageButton imageButton = go.transform.GetChild(0).GetComponent<ImageButton>();
            GameObject window=go.transform.GetChild(1).gameObject;

            window.GetComponent<WindowManager>().SetValue(videoDir + "/" + videoNames[i]);
            imageButton.SetValue(picDir+"/"+picNames[i],window);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitProduct();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
