using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CreateObjManager : MonoBehaviour
{
    public Transform parent;
    GameObject [] experts;
    Sequence sequence;
    HorizontalLayoutGroup horizontalLayoutGroup;

    private void Awake()
    {
       // horizontalLayoutGroup = parent.GetComponent<HorizontalLayoutGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 实例化专家图片
    /// </summary>
    public  void CreateObj()
    {
        experts = new GameObject[ExpertList.expertModels.Count];
        //horizontalLayoutGroup.enabled = true;
        for (int i = 0; i < ExpertList.expertModels.Count; i++)
        {
            GameObject objPrefab = Resources.Load<GameObject>("Prefabs/expert");
            GameObject objGo = Instantiate(objPrefab, parent);
            //objGo.transform.localScale = Vector3.one;
            objGo.transform.localPosition = Vector3.zero;

            if (objGo.GetComponent<ExpertIcon>())
            {
                objGo.GetComponent<ExpertIcon>().SetValue(i.ToString(),
                    ExpertList.expertModels[i].title, ExpertList.expertModels[i].subtitle);

                //if (i==ExpertList.expertModels.Count-1)
                //{
                //    objGo.GetComponent<ExpertIcon>().IsLast=true;
                //}
            }

            experts[i] = objGo;
        }

        ShowExpert();
    }

    /// <summary>
    /// 专家图片 dotween 动画
    /// </summary>
   public void ShowExpert()
    {
        //隐藏最后一张图的蓝色线条
        experts[experts.Length - 1].GetComponent<ExpertIcon>().HideBlue();
        // horizontalLayoutGroup.enabled = false;
        sequence = DOTween.Sequence();
        for (int i = 0; i < experts.Length; i++)
        {       
            sequence.AppendInterval(0.2f);
            sequence.Append(experts[i].transform.DOLocalMoveY(350, 0.8f));                             
        }
    }


    private void OnEnable()
    {
        CreateObj();
    }

    private void OnDisable()
    {
        sequence.Kill();
        if (parent!=null&& parent.childCount>=1)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }   
    }

}
