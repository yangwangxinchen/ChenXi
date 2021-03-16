using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCXPlanel : MonoBehaviour
{
    GameObject page;
    GameObject planetPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        page = transform.GetChild(0).gameObject;
        planetPanel = GameObject.FindGameObjectWithTag("planetPanel");
    }

    public  void ClosePanel()
    {
        Debug.Log("关闭");
        //一级目录出现
        planetPanel.transform.GetChild(0).gameObject.SetActive(true);
        //page.SetActive(false);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("VideoWindow"))
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        
    }
}
