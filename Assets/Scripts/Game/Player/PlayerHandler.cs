using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float maxHealth = 100;
    public float curHealth;
    public float maxStamina = 100;
    public float curStamina;
    public float maxMana = 100;
    public float curMana;

    public int strength;
    public int dexterity;
    public int constatution;
    public int intelligence;
    public int wisdom;
    public int charisma;

    public bool showUI = true;
    private PlayerUI uI;
    private Pausing pausing;

    void Start()
    {
        curHealth = maxHealth;
        curStamina = maxStamina;
        curMana = maxMana;
        uI = GetComponent<PlayerUI>();
        pausing = GetComponent<Pausing>();
    }

    void Update()
    {
        if (curStamina > maxStamina)
        {
            curStamina = maxStamina;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerLooking.Freeze();
            if (pausing.showPause)
            {
                showUI = true;
                pausing.showPause = false;
            }
            else
            {
                showUI = false;
                pausing.showPause = true;
            }
        }
        uI.enabled = showUI;
    }
}
