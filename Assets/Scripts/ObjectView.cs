using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ObjList的初始化
public class ObjectView : MonoBehaviour {

    public GameObject itemPrefab;
    public ScrollRect scroll;
    public GridLayoutGroup grid;

    void Start()
    {
        InitScrollItem();
    }

    void InitScrollItem()
    {
        for( int i = 0;i < ObjectManager.ObjectList.Count;i++ )
        {
            GameObject itemObj = Instantiate(itemPrefab, grid.transform);
            ViewButton target = itemObj.GetComponent<ViewButton>();
            target.myTarget = ObjectManager.ObjectList[i];
            target.targetName = ObjectManager.ObjectList[i].transform.GetChild(0).GetChild(0).GetComponent<Text>();
            itemObj.GetComponent<Image>().color = ObjectManager.ObjectList[i].GetComponent<Renderer>().material.color;
        }
    }
}
