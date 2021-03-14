using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//改变物体材质
public class ChangePhysical : MonoBehaviour {

    Rigidbody2D rg;

    private int indx = 0;
    private void Start()
    {
        rg = transform.parent.Find("AddForceBotton").GetComponent<AddForceBotton>().Target;
    }

    public void SetMat()
    {
        indx = GetComponent<Dropdown>().value;
        switch (indx)
        {

            case 0:
                Set(0, 0);
                break;
            case 1:
                Set(1, 1f);
                break;
            case 2:
                Set(1, 0);
                break;
            case 3:
                Set(0, 1f);
                break;
            case 4:
                Set(0.6f, 0);
                break;
            case 5:
                Set(0.6f, 0.6f);
                break;
            case 6:
                Set(0, 0.6f);
                break;


        }       
    }


    void Set(float x, float y)
    {
        PhysicsMaterial2D physicsMaterial = new PhysicsMaterial2D(rg.name)
        {
            friction = x, bounciness = y
        };
        rg.transform.gameObject.GetComponent<Rigidbody2D>().sharedMaterial = physicsMaterial;
        rg.transform.gameObject.GetComponent<Collider2D>().sharedMaterial = physicsMaterial;
        
    }
}
