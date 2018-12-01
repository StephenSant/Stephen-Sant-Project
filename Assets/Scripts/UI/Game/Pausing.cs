﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    public int mainMenu = 0;
    private static bool showPause;

    public static bool TogglePause()
    {
        if (showPause)
        {
            showPause = false;
            PlayerUI.Freeze();
            return (false);
        }
        else
        {
            showPause = true;
            PlayerUI.Freeze();
            return (true);
        }
    }

    void OnGUI()
    {
        //screen scaling
        Vector2 scr = Vector2.zero;
        if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
        if (showPause)
        {
            //background
            GUI.Box(new Rect(scr.x * 0, scr.y * 0, scr.x* 16.2f, scr.y*9.1f),"");
            GUI.Box(new Rect(scr.x * 5f, scr.y * 1f, scr.x * 6f, scr.y * 2),"Paused");
            if(GUI.Button(new Rect(scr.x *6.5f, scr.y *4f, scr.x*3f, scr.y*1f), "Resume"))
            {
                PlayerUI.Freeze();
                showPause = false;
            }
            if (GUI.Button(new Rect(scr.x *6.5f, scr.y *5.1f, scr.x*3f, scr.y*1f), "Save"))
            {
                
            }
            if (GUI.Button(new Rect(scr.x *6.5f, scr.y *6.2f, scr.x*3f, scr.y*1f), "Exit To Menu"))
            {
                SceneManager.LoadScene(mainMenu);
            }
        }
    }

}