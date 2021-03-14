using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//加载指定场景
public class LoadSence : MonoBehaviour {
    private GameObject objManager;

    public SenceList.Sence sence;
    public void Load()
    {
        objManager = GameObject.Find("ObjectManager");
        objManager.SendMessage("Initatal");
        objManager.SendMessage("Resets");
        DontDestroyOnLoad(objManager);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sence.ToString());
        Time.timeScale = 1;
    }
}
