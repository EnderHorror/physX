using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//管理一些文本框的输入
public class PannelMamager : MonoBehaviour {


    public Vector2 InputVector;
    public float mass;

    private float unchekeMass;

    private InputField x;
    private InputField y;
    private InputField inputMass;

    private float xF;
    private float yF;


    private void Start()
    {
        x = transform.Find("InputFieldX").GetComponent<InputField>();
        y = transform.Find("InputFieldY").GetComponent<InputField>();
        inputMass =transform.Find("MassInput").GetComponent<InputField>();

        inputMass.text = transform.Find("AddForceBotton").GetComponent<AddForceBotton>().Target.mass.ToString();
    }

    void Update () {
        InputLimit.Limit(x);
        InputLimit.Limit(y);
        float.TryParse(x.text, out xF);
        float.TryParse(y.text, out yF);

        InputVector = new Vector2(xF, yF);

        InputLimit.Limit(inputMass);
        float.TryParse(inputMass.text,out unchekeMass);
        if(unchekeMass > 0)
        {
            mass = unchekeMass;
        }
        else
        {
            inputMass.text = mass.ToString();
        }
    }
}
