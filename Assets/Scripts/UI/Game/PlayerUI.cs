using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHandler))]
public class PlayerUI : MonoBehaviour
{
    private PlayerHandler handler;

    public GUIStyle background;
    public GUIStyle healthBackground;
    public GUIStyle healthForeground;
    public GUIStyle stamina;
    public GUIStyle mana;
    public RenderTexture miniMap;

    private static bool isFrozen = false;
    private static bool showUI = true;

    // Use this for initialization
    void Start()
    {
        handler = GetComponent<PlayerHandler>();
    }

    public static bool Freeze()
    {
        if (isFrozen)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isFrozen = false;
            showUI = true;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isFrozen = true;
            showUI = false;
        }
        return isFrozen;

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
        if (showUI)
        {
            //black background
            GUI.Box(new Rect(scr.x * 4.5f, scr.y * 0, scr.x * 6f, scr.y * 1f), "", background);
            //stamina
            GUI.Box(new Rect(scr.x * 10f, scr.y * 1f, scr.x * 0.5f, scr.y * 1f * -(handler.curStamina / handler.maxStamina)), "", stamina);
            //mana
            GUI.Box(new Rect(scr.x * 4.5f, scr.y * 1f, scr.x * 0.5f, scr.y * 1f * -(handler.curMana / handler.maxMana)), "", mana);
            //red background
            GUI.Box(new Rect(scr.x * 5f, scr.y * 0, scr.x * 5f, scr.y * 1f), "", healthBackground);
            //green health bar
            GUI.Box(new Rect(scr.x * 5f, scr.y * 0, scr.x * 5f * (handler.curHealth / handler.maxHealth), scr.y * 1f), "", healthForeground);
            //mini-map
            GUI.DrawTexture(new Rect(scr.x * 14.2f, scr.y * 0f, scr.x * 2f, scr.y * 2f), miniMap);
            //crosshair
            GUI.Box(new Rect(scr.x * 8, scr.y * 4.5f, scr.x * .1f, scr.y * .1f), "");
        }
    }
}
