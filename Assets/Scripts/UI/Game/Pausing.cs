using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    public int mainMenu = 0;
    private static bool showPause;

    public GUIStyle backgroundStyle;
    public GUIStyle pauseTextStyle;
    public GUIStyle buttonStyle;

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
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

            //background
            GUI.Box(new Rect(scr.x * 0, scr.y * 0, scr.x* 16.2f, scr.y*9.1f),"",backgroundStyle);
            GUI.Box(new Rect(scr.x * 5f, scr.y * 1f, scr.x * 6f, scr.y * 2),"Paused",pauseTextStyle);
            if(GUI.Button(new Rect(scr.x *6.5f, scr.y *4f, scr.x*3f, scr.y*1f), "Resume",buttonStyle))
            {
                PlayerUI.Freeze();
                showPause = false;
            }
            if (GUI.Button(new Rect(scr.x *6.5f, scr.y *5.1f, scr.x*3f, scr.y*1f), "Save", buttonStyle))
            {
                gameManager.SaveGame();
            }
            if (GUI.Button(new Rect(scr.x *6.5f, scr.y *6.2f, scr.x*3f, scr.y*1f), "Exit To Menu", buttonStyle))
            {
                gameManager.SaveGame();
                PlayerUI.Freeze();
                showPause = false;
                SceneManager.LoadScene(mainMenu);

                // Destroy the GameManager
                Destroy(gameManager.gameObject);
            }
        }
    }

}
