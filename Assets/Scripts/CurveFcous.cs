using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
//曲线编辑器焦点按钮
public class CurveFcous : MonoBehaviour {

    Draw2DUILine draw;
	void Start () {
        draw = GameObject.Find("Draw2DLineGraphCanvas").GetComponent<Draw2DUILine>();
	}
	
    public void CruveFoucs()
    {
        draw.rg = transform.parent.Find("AddForceBotton").GetComponent<AddForceBotton>().Target;
    }

}
