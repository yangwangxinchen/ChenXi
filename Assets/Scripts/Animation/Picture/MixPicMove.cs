using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 体验体系动画
/// </summary>
public class MixPicMove : MonoBehaviour
{

    List<ExperiencePicMove> experiencePicMoves = new List<ExperiencePicMove>();

    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        experiencePicMoves[0].PicMoveY();
    }
    public void Init()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ExperiencePicMove>() != null)
            {
                experiencePicMoves.Add(transform.GetChild(i).GetComponent<ExperiencePicMove>());
            }
        }
        for (int i = 0; i < experiencePicMoves.Count; i++)
        {
            if (i != experiencePicMoves.Count - 1)
            {
                experiencePicMoves[i].nextPicMove = experiencePicMoves[i + 1];
            }
        }

        
    }
    private void OnEnable()
    {
        experiencePicMoves[0].PicMoveY();
    }

    private void OnDisable()
    {
        for (int i = 0; i < experiencePicMoves.Count; i++)
        {
            experiencePicMoves[i].ResetDefault();
        }
    }
}
