using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePicManager : MonoBehaviour
{
    List<PlanePicMove> orderMoves = new List<PlanePicMove>();
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            PlanePicMove temp = transform.GetChild(i).GetComponent<PlanePicMove>();
            orderMoves.Add(temp);
        }

        for (int i = 0; i < orderMoves.Count; i++)
        {
            if (i != orderMoves.Count - 1)
            {
                orderMoves[i].next = orderMoves[i + 1];
            }
        }
    }
    private void Start()
    {
        if (orderMoves.Count > 0)
        {
            orderMoves[0].TweenMove();
        }
    }
    private void OnEnable()
    {
        if (orderMoves.Count > 0)
        {
            orderMoves[0].TweenMove();
        }     
    }

    private void OnDisable()
    {
        if (orderMoves.Count > 0)
        {
            for (int i = 0; i < orderMoves.Count; i++)
            {
                orderMoves[i].ResetDefault();
            }
        }

    }




}
