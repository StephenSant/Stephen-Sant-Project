using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

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

    private CharacterPrefs data = new CharacterPrefs();
    public string fileName = "CharacterPrefs";

    void Start()
    {
        
        curStamina = maxStamina;
        curMana = maxMana;
        uI = GetComponent<PlayerUI>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        string filePath = Application.persistentDataPath + "/" + fileName + ".xml";
        if (File.Exists(filePath))
        {
            var serializer = new XmlSerializer(typeof(CharacterPrefs));
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                data = serializer.Deserialize(stream) as CharacterPrefs;
            }

            strength = data.playerStats[0];
            dexterity = data.playerStats[1];
            constatution = data.playerStats[2];
            intelligence = data.playerStats[3];
            wisdom = data.playerStats[4];
            charisma = data.playerStats[5];

            if (data.playerName!="Adventurer") { gameObject.name = data.playerName + " the " + data.playerClass; }

        }
        curHealth = maxHealth;
        

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
