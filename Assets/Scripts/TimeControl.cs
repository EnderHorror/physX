using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//时间控制按钮的开关
public class TimeControl : MonoBehaviour {

    private bool isPuse = true;
    private Text text;
    private GameObject attention;
    private Image image;
    private void Start()
    {
        Time.timeScale = 0;
        text = GetComponentInChildren<Text>();
        attention = transform.Find("Attention").gameObject;
        image = GetComponent<Image>();
        image.color = Color.green;
    }
    public void TimeSet()
    {
        if (isPuse)
        {
            Time.timeScale = 1;
            isPuse = false;
            text.text = "暂停";
            image.color = Color.red;
            attention.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            isPuse = true;
            text.text = "继续";
            image.color = Color.green;
            attention.SetActive(true);
        }
    }

}
