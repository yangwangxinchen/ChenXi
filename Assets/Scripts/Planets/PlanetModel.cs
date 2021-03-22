using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetModel 
{
    public int id;
    public string planetName;
    public string titleName;
    public float width;
    public float height;
    public float duration;
    public float scale;
    public float angle;
    public int num;

    public PlanetModel(int id, string planetName, string titleName, float width, float height, float duration, float scale, float angle,int num)
    {
        this.id = id;
        this.planetName = planetName;
        this.titleName = titleName;
        this.width = width;
        this.height = height;
        this.duration = duration;
        this.scale = scale;
        this.angle = angle;
        this.num = num;
    }

}

public class PlanetList
{
    public static List<PlanetModel> planetModels = new List<PlanetModel>
    {
        //new PlanetModel (1,"水星","走进晨曦",2,1,30,0.7f,-50,30),
        //new PlanetModel (2,"金星","品牌文化",4,2,40,0.9f,-55,40),
        //new PlanetModel (3,"地球","品牌巡礼",6,3,50,1,-60,50),
        //new PlanetModel (4,"火星","团队风采",8,4,60,0.8f,-50,60),
        //new PlanetModel (5,"木星","品牌战略",10,5,70,2,-50,70),
        //new PlanetModel (6,"土星","强大资源",12,6,80,1.8f,-50,80),
        //new PlanetModel (7,"天王星","荣誉见证",14,7,90,1.6f,-50,90),
        //new PlanetModel (8,"海王星","未来展望",16,8,100,1.4f,-60,100)  
         new PlanetModel (1,"水星","走进晨曦",3,1.5f,30,1.6f,-50,30),
        new PlanetModel (2,"金星","品牌文化",6,3,40,1.6f,-55,40),
        new PlanetModel (3,"地球","品牌巡礼",9,4.5f,50,1.6f,-60,50),
        new PlanetModel (4,"火星","团队风采",12,6,60,1.6f,-50,60),
        new PlanetModel (5,"木星","品牌战略",15,7.5f,70,2.5f,-50,70),
        new PlanetModel (6,"土星","强大资源",18,9,80,1.8f,-50,80),
        new PlanetModel (7,"天王星","荣誉见证",21,10.5f,90,2.2f,-50,90),     
        new PlanetModel (8,"海王星","未来展望",24,12,100,1.8f,-60,100)
    };
}
