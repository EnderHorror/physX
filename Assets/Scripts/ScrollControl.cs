using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//焦点控制器
public class ScrollControl : MonoBehaviour {
    public bool canScroll = true;

    public void ChnageStaueOn()
    {
        canScroll = true;
    }

    public void ChnageStaueOff()
    {
        canScroll = false;
    }

}
