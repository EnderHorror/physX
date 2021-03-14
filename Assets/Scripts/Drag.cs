using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//窗口拖拽区域
public class Drag : MonoBehaviour {

    private Vector2 offset;	
	

    public void SetPos()
    {
        offset = transform.parent.position - Input.mousePosition;
    }

    public void Move()
    {
        transform.parent.position = (Vector2)Input.mousePosition + offset;
    }
}
