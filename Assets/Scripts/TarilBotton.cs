using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//轨迹按钮
public class TarilBotton : MonoBehaviour {

    Rigidbody2D rg;

    void Start () {
         rg = transform.parent.Find("AddForceBotton").GetComponent<AddForceBotton>().Target;
    }

    public void TrailEnable()
    {
        rg.transform.GetComponent<TrailRenderer>().enabled = GetComponent<Toggle>().isOn;
    }
}
