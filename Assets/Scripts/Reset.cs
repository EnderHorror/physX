using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//物体本身复原
public class Reset : MonoBehaviour {

    private Vector3 innitatalPos;

	void Start ()
    {
        innitatalPos = transform.position;
        PhysicsMaterial2D physicsMaterial = new PhysicsMaterial2D(transform.name)
        {
            friction = 0,
            bounciness = 0
        };
        GetComponent<Rigidbody2D>().sharedMaterial = physicsMaterial;
        GetComponent<Collider2D>().sharedMaterial = physicsMaterial;
    }

    public void ResetPos()
    {
        transform.position = innitatalPos;
        transform.rotation = Quaternion.identity;
        transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        transform.GetComponent<ConstantForce2D>().force = Vector2.zero;
        GetComponent<TrailRenderer>().Clear();
    }
}
