using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//色表
public class ColorList : MonoBehaviour {
    public static List<Color> ColourList = new List<Color>() { new Color(0.4339f, 0.3909f, 0.3909f),
        new Color(0.1806248f, 0.9339f, 0.8343f),
    Color.red,new Color(0.5272f, 0.9333f, 0.1803f),
    new Color(0.93333f, 0.9206f, 0.1803f)};

    private void Awake()
    {
        Resets();
    }

    public void Resets()
    {
       if(ColourList.Count != 0)
        {
            ColourList.RemoveAll(it => true);
        }

        ColourList.Add(new Color(0.4339f, 0.3909f, 0.3909f));
        ColourList.Add(Color.red);
        ColourList.Add(new Color(0.1806248f,0.9339f,0.8343f));
        ColourList.Add(new Color(0.5272f, 0.9333f, 0.1803f));
        ColourList.Add(new Color(0.93333f, 0.9206f, 0.1803f));
    }
}
