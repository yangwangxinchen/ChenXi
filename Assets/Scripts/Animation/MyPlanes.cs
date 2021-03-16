using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Text;
using System;


public class MyPlanes : MonoBehaviour
{
    public int index;
    public float speed;

    PlanesGM PlanesGM;
    // Start is called before the first frame update
    void Start()
    {
        PlanesGM = transform.parent.GetComponent<PlanesGM>();
        
    }

    
    // Update is called once per frame
    void Update()
    {

    }

    public void TurnLeft()
    {
        if (index != 1)
        {
            transform.DOLocalMove(PlanesGM.planesPos[index - 2], speed);
            transform.DOLocalRotate(PlanesGM.planesAng[index - 2], speed);
        }
        else
        {
            transform.DOLocalMove(PlanesGM.planesPos[transform.parent.childCount - 1], speed);
            transform.DOLocalRotate(PlanesGM.planesAng[transform.parent.childCount - 1], speed);
        }
        index--;
        IndexOnRange();
    }

    
    public void TurnRight()
    {
        if (index != transform.parent.childCount)
        {
            transform.DOLocalMove(PlanesGM.planesPos[index], speed);
            transform.DOLocalRotate(PlanesGM.planesAng[index], speed);

        }
        else
        {
            transform.DOLocalMove(PlanesGM.planesPos[0], speed);
            transform.DOLocalRotate(PlanesGM.planesAng[0], speed);
        }
        index++;
        IndexOnRange();
    }

    private void IndexOnRange()
    {
        if (index < 1)
        {
            index = transform.parent.childCount;
        }
        if (index > transform.parent.childCount)
        {
            index = 1;
        }
    }

}
