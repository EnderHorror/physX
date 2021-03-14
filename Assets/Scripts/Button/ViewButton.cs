using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//选择物体显示窗口按钮
public class ViewButton : MonoBehaviour {
    [HideInInspector]public ControlMeun myTarget;
    [HideInInspector]public Text targetName;

    private Text myText;

    private void Start()
    {
        myText = transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        if(targetName != null)
        {
            myText.text = targetName.text;
        }
    }

    public void Select()
    {
        myTarget.currentWindow.SetActive(true);
    }
}
