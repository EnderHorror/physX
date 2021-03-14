using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//2D3D切换按钮
public class CameraSwitch : MonoBehaviour {

    private new Camera camera ;
    public Transform prespectivePos;
    private bool canSwitch = true;

    public void Switch()
    {
        if (canSwitch)
        {
            camera = Camera.main;
            camera.GetComponent<CameraConrol>().Switching = true;
            if (camera.orthographic)
            {
                camera.orthographic = false;
            }
            else
            {
                camera.orthographic = true;
            }
            canSwitch = false;
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        camera.GetComponent<CameraConrol>().Switching = false;
        canSwitch = true;
    }
}
