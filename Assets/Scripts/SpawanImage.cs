using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawanImage : MonoBehaviour
{

    public int row=5;
    public int col=5;
    public GameObject pb;
    public Transform parent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SpawnRow(int count,int y)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(pb, parent);
            go.transform.localPosition = new Vector3(count * 50, y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
