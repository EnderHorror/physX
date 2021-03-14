using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//聚焦物体按钮
public class FocusOn : MonoBehaviour {

    public void Focus()
    {
        Camera.main.GetComponent<CameraConrol>().focus = 
        transform.parent.Find("AddForceBotton").GetComponent<AddForceBotton>().Target.transform;
        Camera.main.GetComponent<CameraConrol>().isFlollowing = true;
    }
}
