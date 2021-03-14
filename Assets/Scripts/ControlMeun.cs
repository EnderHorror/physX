using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//物体Window初始化
public class ControlMeun : MonoBehaviour {

    public GameObject Window;
    public bool isSlected = false;
    [HideInInspector]
    public GameObject currentWindow;
    private Rigidbody2D rg;
    private Text volocityDisplay;

    private void OnEnable()
    {
        ObjectManager.ObjectList.Add(GetComponent<ControlMeun>());
        int index = Random.Range(0, ColorList.ColourList.Count - 1);
        Color color = ColorList.ColourList[Random.Range(0, index)];
        ColorList.ColourList.Remove(color);
        GetComponent<Renderer>().material.color = color;

    }


    void Start ()
    {
        

        rg  = GetComponent<Rigidbody2D>();
        if (currentWindow == null)
        {
            //生成窗口并获取窗口
            currentWindow = Instantiate(Window, transform.position, Quaternion.identity);
            currentWindow.transform.GetChild(0).position += new Vector3(transform.position.x * 20, -200, 0);
            volocityDisplay = currentWindow.transform.GetChild(0).Find("SpeedTextBox").GetComponent<Text>();
            currentWindow.transform.GetChild(0).Find("AddForceBotton").GetComponent<AddForceBotton>().Target = rg;
            if(gameObject.GetComponent<Renderer>().material.color != null)
            {
                currentWindow.transform.GetChild(0).Find("Panel").GetComponent<Image>().color = gameObject.GetComponent<Renderer>().material.color;
            }
            currentWindow.SetActive(false);
        }
    }

    void Update ()
    {       
        volocityDisplay.text = "速度：" + rg.velocity.ToString();
	}

    private void OnMouseDown()
    {
        isSlected = true;
        if (currentWindow != null)
        {
            currentWindow.SetActive(true);
        }
    }

    
}
