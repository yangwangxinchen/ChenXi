using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertModel
{
    public string spritePath;
    public string title;
    public string subtitle;
    public ExpertModel(string _spritePath, string _title, string _subtitle)
    {
        spritePath = _spritePath;
        title = _title;
        subtitle = _subtitle;
    }

}

public class ExpertList
{
    public static List<ExpertModel> expertModels = new List<ExpertModel>
    {
        new ExpertModel("0", "Dr. ZanderHuan", "美国康奈尔大学生物\n学教授 国际知名生\n物学、干细胞学和基\n因学专家"),
        new ExpertModel("1", "蒋波", "博士、国际知名生物\n材料研发专家 20余\n年创新化学药和生物\n材料开发经验"),
        new ExpertModel("2", "周晴中", "北京大学化学与分子\n工程学院教授\n曾担任埃默里大学和\n美国疾病研究中心中\n国留学生联谊会主席"),
        new ExpertModel("3", "李海航", "华南师范大学生命科\n学学院教授、博导\n广东省植物学会理事"),
        new ExpertModel("4", "金涌", "中国工程院院士\n化学工程专家"),
        new ExpertModel("5", "熊晓云", "国家级企业技术中心\n主任 健康科学研究院\n院长"),
        new ExpertModel("6", "Dr Jim Xie", "化学博士，拥有20年\n多肽从业经验，具有\n丰富的多肽研发"),
        new ExpertModel("7", "王浩", "南开大学化学博士\n美国加州大学博士后"),
        new ExpertModel("8", "蔡义文", "华南理工大学生物工\n程硕士 高级工程师\n（副高）职称"),
        new ExpertModel("9", "梁雅玲", "医学硕士 抗衰免疫\n治疗高级顾问"),
        new ExpertModel("10", "蓝柯", "教授、博士、著名生\n物学家")

    };
}

