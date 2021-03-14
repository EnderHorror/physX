using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

//文本框输入验证
public static class InputLimit {

    public static void Limit(InputField inputField)
    {
        Regex regex;
        Regex regexDou;
        regex = new Regex(@"^([-]{0,1})[0-9]+([.]{0,1}[0-9]+){0,1}$");
        regexDou = new Regex(@"^([-]{0,1})[0-9]+([.]{0,1})$");

        if (regex.IsMatch(inputField.text))
        {
            inputField.text = regex.Match(inputField.text).Value;
        }
        else
        {
            if (inputField.text != "" && inputField.text.Length > 1)
            {
                if (!regexDou.IsMatch(inputField.text))
                {
                    inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
                }
            }
        }
       
    } 

}
