using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//控制选项按钮
public class InspectorOption : MonoBehaviour {
    public GameObject togglePre;

    private GridLayoutGroup grid;
    private GameObject window;
	void Start () {
        window = transform.parent.Find("Option Scroll View").gameObject;
        grid = window.transform.GetChild(0).GetChild(0).GetComponent<GridLayoutGroup>();

        GameObject[] Ins = new GameObject[] { };
        Ins = GameObject.FindGameObjectsWithTag("Inspector");
        for (int i = 0; i < Ins.Length; i++)
        {
            GameObject Toggel = Instantiate(togglePre,grid.transform);
            Toggel.GetComponentInChildren<Text>().text = Ins[i].name + "Toggle";
            Toggel.GetComponent<WindowToggle>().myObj = Ins[i];
        }
        window.SetActive(false);
    }


    public void Open()
    {
        if(window.activeSelf)
        {
            window.SetActive(false);
        }
        else
        {
            window.SetActive(true);
        }
    }
}
