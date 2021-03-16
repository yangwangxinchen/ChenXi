using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.platform==RuntimePlatform.WindowsPlayer)
            {
                Application.Quit();
            }

            //else if (Application.platform == RuntimePlatform.WindowsEditor)
            //{
            //    UnityEditor.EditorApplication.isPlaying = false;
            //}
        }
    }
}
