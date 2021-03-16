using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePos : MonoBehaviour
{
    public int num=5;
    public float radius = 5;
    GameObject[] GOs;
    void Start()
    {
        GOs = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            float angle = i * 2 * Mathf.PI / num;
           GameObject go= GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.SetParent(this.transform);
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            go.transform.localPosition = new Vector3(x, 0, y);
            GOs[i] = go;
        }

        InvokeRepeating("Rotate", 1, 3);
    }

    public void Rotate()
    {
        //for (int i = 0; i < GOs.Length; i++)
        //{
        //    GOs[i].transform.RotateAround(transform.position , GOs[i].transform.up,(2 * Mathf.PI / num)*Mathf.Rad2Deg);
        //}
    }
}
