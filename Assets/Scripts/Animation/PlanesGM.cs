using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesGM : MonoBehaviour
{
    //public static PlanesGM instance;

    public  List<Vector3> planesPos = new List<Vector3>();
    public  List<Vector3> planesAng = new List<Vector3>();
    public AudioSource source;
    public int index;
    private void Awake()
    {

    }


    private void OnEnable()
    {
        if (planesPos.Count != 0)
        {
            InvokeRepeating("RotateSelf", 1, 3);
            Invoke("PlaySound", 0.5f);
        }
    }

    void Start()
    { 
        
        index = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            planesPos.Add(transform.GetChild(i).localPosition);
            planesAng.Add(transform.GetChild(i).localEulerAngles);
        }

        InvokeRepeating("RotateSelf", 1, 3);
        Invoke("PlaySound", 0.5f);
    }


    float timer;
    // Update is called once per frame
    void Update()
    {



    }



    private void OnDisable()
    {
       CancelInvoke("RotateSelf");
    }
    public void PlaySound()
    {
        source.Play();
    }
    public void RotateSelf()
    {
        RightChange();
        //LeftChange();
    }



    public void LeftChange()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MyPlanes>().TurnLeft();
        }
        index++;
        IndexOnRange();
    }

    public void RightChange()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MyPlanes>().TurnRight();
        }
        index--;
        IndexOnRange();
    }

    private void IndexOnRange()
    {
        if (index < 0)
        {
            index = transform.childCount - 1;
        }
        if (index > transform.childCount - 1)
        {
            index = 0;
        }
    }

}