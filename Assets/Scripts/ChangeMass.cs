using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//改变质量
public class ChangeMass : MonoBehaviour {

    public void Changed()
    {
        Rigidbody2D rg = transform.parent.Find("AddForceBotton").GetComponent<AddForceBotton>().Target;
        float mass = transform.parent.GetComponent<PannelMamager>().mass;
        if(mass != 0)
        {
            rg.mass = mass;
        }
    }
}
