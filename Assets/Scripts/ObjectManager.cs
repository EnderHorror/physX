using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//物体管理器
public class ObjectManager : MonoBehaviour {

    public static List<ControlMeun> ObjectList = new List<ControlMeun>();
    public static int ObjectCount = 0;


    public void Initatal()
    { 
        
        for(int i = 0; i< ObjectCount; i++)
        {
            ObjectList.Remove(ObjectList[0]);
        }
        ObjectCount = 0;
    }
}
