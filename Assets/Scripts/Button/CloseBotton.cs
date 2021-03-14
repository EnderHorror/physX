using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//关闭窗口按钮
public class CloseBotton : MonoBehaviour {

    public void Close()
    {
        transform.parent.parent.gameObject.SetActive(false);
    }
}
