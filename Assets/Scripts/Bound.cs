using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//可拖动窗口边界限制
public class Bound : MonoBehaviour {

    private new RectTransform transform;
	void Start () {
        transform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        //右
		if(transform.position.x > Screen.width)
        {
            transform.position = new Vector3(Screen.width, transform.position.y);
        }
        //左
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y);
        }
        //下
        if (transform.position.y - 200 < 0)
        {
            transform.position = new Vector3(transform.position.x,200);
        }
        //Up
        if (transform.position.y > Screen.height)
        {
            transform.position = new Vector3(transform.position.x, Screen.height);
        }
    }
}
