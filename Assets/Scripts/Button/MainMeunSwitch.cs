using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//主菜单相机切换
public class MainMeunSwitch : MonoBehaviour {

    public int target = 0;

    public void Switch()
    {
        CameMenuControl.targetIndex = target;
    }
}
