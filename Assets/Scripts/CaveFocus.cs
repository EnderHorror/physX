using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
//曲线聚焦
public class CaveFocus : MonoBehaviour {

    Draw2DUILine Draw2DUILine;
    RectTransform Recttransform;
    
	void Start () {
        Draw2DUILine = GetComponentInChildren<Draw2DUILine>();
        Recttransform = GetComponent<RectTransform>();
	}
	
	void FixedUpdate () {
        if (Draw2DUILine.X %1000 >280)
        {
            transform.position = new Vector2(-Draw2DUILine.X % 1000 + 280, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(0, transform.position.y);
        }

    }
}
