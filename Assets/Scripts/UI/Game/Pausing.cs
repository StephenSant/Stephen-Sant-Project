using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    public int mainMenu = 0;
    public bool showPause;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnGUI()
    {
        Vector2 scr = new Vector2(Screen.width,Screen.height);
        if (showPause)
        {
            GUI.Box(new Rect(scr.x * 0, scr.y * 0, scr.x, scr.y),"");
            GUI.Box(new Rect(scr.x * 0.35f, scr.y * 0.1f, scr.x * .3f, scr.y * .2f),"Paused");
            if(GUI.Button(new Rect(scr.x *0.4f, scr.y *0.4f, scr.x*.2f, scr.y*.1f), "Resume"))
            {
                PlayerLooking.Freeze();
                showPause = false;
            }
            if (GUI.Button(new Rect(scr.x *0.4f, scr.y *0.51f, scr.x*.2f, scr.y*.1f), "Save"))
            {
                
            }
            if (GUI.Button(new Rect(scr.x *0.4f, scr.y *0.62f, scr.x*.2f, scr.y*.1f), "Exit To Menu"))
            {
                SceneManager.LoadScene(mainMenu);
            }
        }
    }

}
