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
    private Inventory inventory;

    void Start()
    {
        curHealth = maxHealth;
        curStamina = maxStamina;
        curMana = maxMana;
        uI = GetComponent<PlayerUI>();
        pausing = GetComponent<Pausing>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (curStamina > maxStamina)
        {
            curStamina = maxStamina;
        }
        if (curMana > maxMana)
        {
            curMana = maxMana;
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausing.TogglePause();
        }
        if (Input.GetKeyDown(GameManager.inventory))
        {
            Inventory.ToggleInv();
        }
        uI.enabled = showUI;
    }
}
