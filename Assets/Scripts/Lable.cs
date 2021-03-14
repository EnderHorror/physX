using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//物体标签
public class Lable : MonoBehaviour {


    private Text myText;
    private Text heText;
    private GameObject currentWindow;
    private bool isAdd = false;


    private void Awake()
    {
    }

    void Start ()
    {
        myText = GetComponent<Text>();
        if(transform.parent.parent.GetComponent<Renderer>() != null)
        {
            myText.color = transform.parent.parent.GetComponent<Renderer>().material.color;
        }
    }



    void Update ()
    {
        transform.rotation = Camera.main.transform.rotation;
        currentWindow = transform.parent.parent.GetComponent<ControlMeun>().currentWindow;
        if(currentWindow != null)
        {
            heText = currentWindow.transform.GetChild(0).Find("NameInput").Find("Text").GetComponent<Text>();
            if(heText.text != "")
            {                
                myText.text = heText.text;
            }
            else
            {
                currentWindow.transform.GetChild(0).Find("NameInput").Find("Placeholder").GetComponent<Text>().text = myText.text;
            }
        }
        
            if (!isAdd)
            {
                ObjectManager.ObjectCount += 1;
                myText.text = (ObjectManager.ObjectCount).ToString();
                isAdd = true;
            }            
        
	}
}
