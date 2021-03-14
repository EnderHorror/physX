using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
//改变重力
public class ChangeGravity : MonoBehaviour {
    private InputField inputField;
    private float F_garvity;
    
    private void Start()
    {
        inputField = GetComponent<InputField>();
        inputField.text = Physics2D.gravity.magnitude.ToString();
    }

    private void Update()
    {
            InputLimit.Limit(inputField);
    }

    public void Gravity()
    {
        if (float.TryParse(inputField.text, out F_garvity))
            Physics2D.gravity = new Vector2(0, -F_garvity);
    }
}
