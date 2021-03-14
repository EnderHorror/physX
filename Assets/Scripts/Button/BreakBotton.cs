using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//刹车按钮
public class BreakBotton : MonoBehaviour {

    public void Break()
    {
        Rigidbody2D  rg= transform.parent.Find("AddForceBotton").GetComponent<AddForceBotton>().Target;
        rg.velocity = Vector2.zero;
        rg.transform.GetComponent<ConstantForce2D>().force = Vector2.zero;

    }
}
