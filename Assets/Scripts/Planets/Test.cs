using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Analyse();
        AddPoints();
    }
    public float w;
    public float h;
    public int num = 100;
    private List<Vector3> points = new List<Vector3>();
    public LineRenderer line;

    public Transform center;
    public Transform velocity;
    public  float GM = 10;
    Vector3 r;
    Vector3 v;
    float f;
    void AddPoints()
    {
        points.Clear();

        r = this.transform.position - center.position;
        v = velocity.position - this.transform.position;
        //利用轨道线速度公式求出轨道半长轴
        w = 1 / (2 / r.magnitude - Mathf.Pow(v.magnitude, 2) / GM);
        //利用开普勒第二定律求出轨道半短轴
        h = Vector3.Cross(v, r).magnitude * Mathf.Sqrt(w / GM);
        //求出焦距
        f = Mathf.Sqrt(w * w - h * h);

        

        for (int i = 0; i <= num; i++)
        {
            float angle = i * 2.0f * Mathf.PI / num;
            float x = w * Mathf.Cos(angle);
            float y = h * Mathf.Sin(angle);
            Vector3 pt = new Vector3(x - f, y, 0) + center.transform.position;
            points.Add(pt);
        }
        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }
    public void Analyse()
    {
        


    }
}
