using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//选项窗口的开关
public class WindowToggle : MonoBehaviour {
    [HideInInspector]
    public GameObject myObj;
	void Start () {
	}
	
    public void Switch()
    {
        if (myObj.activeSelf)
        {
            myObj.SetActive(false);
        }
        else
        {
            myObj.SetActive(true);
        }
    }
}
