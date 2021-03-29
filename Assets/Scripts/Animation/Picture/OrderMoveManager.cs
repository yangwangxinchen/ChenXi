using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMoveManager : MonoBehaviour
{
    List<OrderMove> orderMoves = new List<OrderMove>();
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
           OrderMove temp =transform.GetChild(i).GetComponent<OrderMove>();
           orderMoves.Add(temp);
        }

        for (int i = 0; i < orderMoves.Count; i++)
        {
            if (i!= orderMoves.Count-1)
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
        if (orderMoves.Count>0)
        {         
            orderMoves[0].TweenMove();
        }
       // Debug.Log("orderMoves的数量：" + orderMoves.Count);
    }

    private void OnDisable()
    {
        if (orderMoves.Count>0)
        {
            for (int i = 0; i < orderMoves.Count; i++)
            {
                orderMoves[i].ResetDefault();
            }
        }
        
    }
}
