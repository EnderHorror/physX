using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//开始菜单相机路径控制
public class CameMenuControl : MonoBehaviour {

    public Transform[] WayPoints;
    public static int targetIndex = 0;
    public float smooth;
	void Start () {
		
	}
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, WayPoints[targetIndex].position, Time.deltaTime * smooth);
	}



    
}
