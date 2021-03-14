using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//组合碰撞体的子物体
public class Combine : MonoBehaviour {


	
	void Update () {
        GetComponent<Collider2D>().sharedMaterial = transform.parent.GetComponent<Collider2D>().sharedMaterial;
        GetComponent<Renderer>().material.color = transform.parent.GetComponent<Renderer>().material.color;

    }
}
