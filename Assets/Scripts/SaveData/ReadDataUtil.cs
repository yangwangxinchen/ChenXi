using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadDataUtil 
{

    /// <summary>
    /// 读取“图片”下的图片
    /// </summary>
    /// <param name="filepath">相对于“图片”的相对路径</param>
    /// <returns></returns>
    public static Sprite ReadPicture(string filepath)
    {
        string picPath = Application.streamingAssetsPath + "/图片/" + filepath;
        if (File.Exists(picPath))
        {
            byte[] picBytes = File.ReadAllBytes(picPath);
            Texture2D texture2D = new Texture2D(128, 128);
            texture2D.LoadImage(picBytes);
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one / 2f);
            return sprite;
            
        }

        return null;

    }

    /// <summary>
    /// 读取文件夹下的图片
    /// </summary>
    /// <param name="picDir">文件夹</param>
    /// <returns>文件夹下所有图片名列表</returns>
    public static List<string> ReadPictureContent(string picDir)
    {
        List<string> picNameAndExtensionList = new List<string>();
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath + "/图片/" + picDir);
        
        if (directoryInfo.Exists)
        {
            FileInfo[] infos = directoryInfo.GetFiles();

            if (infos.Length != 0)
            {
                foreach (FileInfo item in infos)
                {
                    //过滤掉.meta文件
                    if (item.Extension.Contains(".meta")) continue;
                    picNameAndExtensionList.Add(item.Name); //1.jpg
                }
            }
        }

        return picNameAndExtensionList;
    }

    /// <summary>
    /// 读取视频的路径
    /// </summary>
    /// <param name="filepath">相对于视频下的视频路径</param>
    /// <returns></returns>
    public static string ReadMovePath(string filepath)
    {
        string picPath = Application.streamingAssetsPath + "/视频/" + filepath+".mov";
        if (File.Exists(picPath))
        {
            return picPath;
        }
        //Debug.Log(picPath);
        return null;
    }


}
