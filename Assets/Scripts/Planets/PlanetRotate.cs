using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 自转和公转
/// </summary>
public class PlanetRotate : MonoBehaviour
{
    Transform planet;
    TextMesh textMesh;
    LineRenderer line;
    GameObject textGo;
    public string title;
    //路径点
    private List<Vector3> points = new List<Vector3>();
    //宽
    float w;
    //高
    float h;
    int num = 10;
    float duration;
    float planetScale=1;
    float rotateAngle = -50;
    public float range=30;
    GameObject lineGo;
    float hh=5;
    private void Awake()
    {
        planet = transform.GetChild(0);
       textMesh = transform.GetChild(1).GetComponent<TextMesh>();
        line = transform.GetChild(2).GetComponent<LineRenderer>();

        textGo = transform.GetChild(1).gameObject;
    }

    float x;
    float y;
    void Start()
    {
        SetValue();
        DrawLine();
        RepeatPath();
        x = Random.Range(100, 360);
        y = Random.Range(100, 360);
    }

    //重复运动
    public void RepeatPath()
    {
        //公转   Ease.OutQuad
        Tween tw=transform.DOPath(points.ToArray(), duration).SetEase(Ease.Linear).SetLoops(-1);
        //tw.PlayBackwards();
        transform.DOGoto(range, true);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //自转
       planet.Rotate(transform.up, rotateAngle * Time.deltaTime, Space.Self);

        //textGo.transform.rotation = Camera.main.transform.rotation;

        //transform.RotateAround(transform.parent.parent.position, new Vector3(0,x,y ), 2 * Time.deltaTime);
    }
   
    void AddPoints()
    {
        points.Clear();
        for (int i = 0; i <= num; i++)
        {
            float angle = -i * 2.0f * Mathf.PI / num;
            float x = w * Mathf.Cos(angle);
            float y = h * Mathf.Sin(angle);
           // float z=hh* Mathf.Cos(angle);
            Vector3 pt = new Vector3(x,0,y);  //-10
            points.Add(pt);
        }

        transform.position = points[0];
    }

    public void SetValue()
    {
        for (int i = 0; i < PlanetList.planetModels.Count; i++)
        {
            if (title == PlanetList.planetModels[i].titleName)
            {
                w = PlanetList.planetModels[i].width;
                h = PlanetList.planetModels[i].height;
                duration = PlanetList.planetModels[i].duration;
                planetScale = PlanetList.planetModels[i].scale;
                rotateAngle = PlanetList.planetModels[i].angle;
                num = PlanetList.planetModels[i].num;
                textMesh.text = title;
                planet.localScale = (Vector3.one) * planetScale;
                //range = PlanetList.planetModels[i].id;
                break;
            }
        }

    }
    public void DrawLine()
    {
        AddPoints();

        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
        line.startWidth = 0.01f;
        line.endWidth = 0.01f;
    }

    private void OnEnable()
    {
       //DrawLine();
       //RepeatPath();
    }

    private void OnDisable()
    {
        //干掉dotween path轨迹
       // transform.DOKill();

    }

}
