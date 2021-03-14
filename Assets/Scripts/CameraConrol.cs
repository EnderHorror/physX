using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//相机控制
public class CameraConrol : MonoBehaviour {

    public float smooth = 5;

    public float fllowSmooth = 5;
    private new Camera camera;
    private Vector3 currentPos;
    private Vector3 CurrentRos;

    public Vector3 TowD_pos;
    public Vector3 TowD_ros;
    public Vector3 ThreeD_pos;
    public Vector3 ThreeD_ros;

    public Transform focus;
    public bool isFlollowing = false;
    public bool Switching= false;
    private bool canScorr = true;
    public ScrollControl[] canScorls;

    void Start () {
        TowD_pos = Vector3.back * 10;
        TowD_ros = Vector3.zero;
        ThreeD_pos = new Vector3(-10f, 10f, -10f);
        ThreeD_ros = new Vector3(37.62f, 32.94f, 0f);
        currentPos = TowD_pos;
        CurrentRos = TowD_ros;


        camera = GetComponent<Camera>();
        canScorls = GetComponentsInChildren<ScrollControl>();
	}
	
	void Update () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 offset= new Vector2(x, y);
        if(!Switching && offset.magnitude >0.05f)
        {
            isFlollowing = false;
            transform.position += (Vector3)offset * 0.2f;
        }

        if (Switching)
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position,currentPos + Vector3.up *10, Time.unscaledDeltaTime * smooth);
            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(CurrentRos),smooth * Time.unscaledDeltaTime);
        }

        Follow();

        //透视
        if (!camera.orthographic)
        {
            //float distance = Input.GetAxis("Mouse ScrollWheel");
            //if (camera.fieldOfView >= 30 && camera.fieldOfView <= 100)
            //{
            //    //camera.fieldOfView += distance * 10;
            //}
            //else if (camera.fieldOfView < 30) camera.fieldOfView = 30;
            //else if (camera.fieldOfView > 30) camera.fieldOfView = 100;
            //currentPos = ThreeD_pos;
            CurrentRos = ThreeD_ros;
            
        }
        else //正交
        {
            float distance = Input.GetAxis("Mouse ScrollWheel");
            if (camera.orthographicSize >= 5 && camera.orthographicSize <= 30)
            {
                foreach (var canscorl in canScorls)
                {
                    if (canscorl.canScroll != true)
                    {
                        canScorr = false;
                        break;
                    }
                }
                if (canScorr)
                {
                    camera.orthographicSize += distance * 5;
                }

                foreach (var canscorl in canScorls)
                {
                    if (canscorl.canScroll == true)
                    {
                        canScorr = true;                      
                    }
                }

            }
            else if (camera.orthographicSize < 5) camera.orthographicSize = 5;
            else if (camera.orthographicSize > 30) camera.orthographicSize = 30;            
            //currentPos = TowD_pos;
            CurrentRos = TowD_ros;
            
        }
        
    } 
    
    void Follow()
    {
        if (focus != null && isFlollowing)
        {
            transform.position = Vector3.Lerp(transform.position, focus.position + new Vector3(0, 0, -10), fllowSmooth);
        }
    }
}
