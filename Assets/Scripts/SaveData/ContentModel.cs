using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentModel {

    public string pageName;
    public string[] contents;

    public ContentModel(string pageName, string[] contents)
    {
        this.pageName = pageName;
        this.contents = contents;
    }
}

public class ContentListModel{
    public static List<ContentModel> contentModels = new List<ContentModel>
    {
        new ContentModel ("留白",new string []{
            "每个人都有自己的思想",
            "每个人都自己的不同",
            "遵循天道",
            "乾坤自定",
             "称为",
             "留白"
        }),
        new ContentModel ("方寸",new string []{
            "方寸之地亦显天地之宽",
            "晨曦公司一直致力于传播科学康养文化理念，在技术层面探求更多的突破，在产品层面力求品质为先，在服务层面但求精耕细作，以客户为本。"
        }),

    };
}
