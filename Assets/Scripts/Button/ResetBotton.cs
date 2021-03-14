using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
//重置按钮
public class ResetBotton : MonoBehaviour {

    private void Start()
    {

    }

    public void ResetPos()
    {       
        Rigidbody2D rg = transform.parent.Find("AddForceBotton").GetComponent<AddForceBotton>().Target;
        GameObject.Find("Draw2DLineGraphCanvas").GetComponent<Draw2DUILine>().SendMessage("Clear");
        rg.SendMessage("ResetPos");
    }
}
