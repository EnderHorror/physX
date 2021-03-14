using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//添加作用力按钮
public class AddForceBotton : MonoBehaviour {

    public Rigidbody2D Target;
    int Mode;
    bool add = false;
    Vector2 targetVector;
    public void Addfoce()
    {
        targetVector = transform.parent.GetComponent<PannelMamager>().InputVector;
        Mode = transform.parent.Find("AddMode").GetComponent<Dropdown>().value;
        switch (Mode)
        {
            case 0:
                Target.velocity = targetVector;
                break;
            case 1:
                Target.AddForce(targetVector);
                break;
            case 2:
                Target.gameObject.GetComponent<ConstantForce2D>().force =targetVector;
                break;
            case 3:
                Target.gameObject.GetComponent<ConstantForce2D>().force = targetVector * Target.mass;
                break;

        }

    }

    
}
