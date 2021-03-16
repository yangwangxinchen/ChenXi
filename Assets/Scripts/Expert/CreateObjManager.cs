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

    public  void CreateObj()
    {
        experts = new GameObject[10];
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

   public void ShowExpert()
    {
       // horizontalLayoutGroup.enabled = false;
        sequence = DOTween.Sequence();
        for (int i = 0; i < experts.Length; i++)
        {       
            sequence.AppendInterval(0.5f);
            sequence.Append(experts[i].transform.DOLocalMoveY(350, 1));                             
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
