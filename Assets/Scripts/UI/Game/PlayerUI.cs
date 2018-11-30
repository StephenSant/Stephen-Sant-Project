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


    // Use this for initialization
    void Start()
    {
        handler = GetComponent<PlayerHandler>();    
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        Vector2 scr = Vector2.zero;
        if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
        GUI.Box(new Rect(scr.x * 2f, scr.y * 0, scr.x * 6f, scr.y * 1f),"",background);
        GUI.Box(new Rect(scr.x * 7.5f, scr.y * 1f, scr.x * 0.5f, scr.y * 1f * -(handler.curStamina / handler.maxStamina)),"",stamina);
        GUI.Box(new Rect(scr.x * 2f, scr.y * 1f, scr.x * 0.5f, scr.y * 1f * -(handler.curMana / handler.maxMana)),"",mana);
        GUI.Box(new Rect(scr.x * 2.5f, scr.y * 0, scr.x * 5f, scr.y * 1f),"",healthBackground);
        GUI.Box(new Rect(scr.x * 2.5f, scr.y * 0, scr.x * 0.5f*(handler.curHealth/handler.maxHealth), scr.y * 0.1f),"", healthForeground);
        GUI.DrawTexture(new Rect(scr.x * 8.7f, scr.y * 0.01f, scr.x * 0.12f, scr.y * 0.2f),miniMap);
        
    }
}
