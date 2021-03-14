using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//行星的力
public class Planet : MonoBehaviour {

    private void Start()
    {
        Physics2D.gravity = Vector2.zero;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 offset = transform.position - collision.transform.position;
        collision.GetComponent<Rigidbody2D>().AddForce
            (offset.normalized * 
            ((collision.GetComponent<Rigidbody2D>().mass * collision.GetComponent<Rigidbody2D>().mass) * 5 / offset.magnitude * offset.magnitude
            ));
    }
}
