#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//编辑器模式下的管理器
public class TestManager : MonoBehaviour {

    public GameObject ObjManager;
    private GameObject current;
	void Start () {
        current = GameObject.Find("ObjectManager");
        if(current == null)
        {
            current = Instantiate(ObjManager);
            current.name = "ObjectManager";
        }
    }

    void Update () {
		
	}
}
#endif