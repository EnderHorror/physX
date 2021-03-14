using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//？？
public class Ciril : MonoBehaviour {

	void Update () {
        transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody>().velocity;
        transform.GetChild(0).transform.position = transform.position;

    }
}
