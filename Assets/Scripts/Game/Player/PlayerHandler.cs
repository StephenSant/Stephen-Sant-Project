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

    public int strenght;
    public int dexterity;
    public int constatution;
    public int intelligence;
    public int wisdom;
    public int charisma;

    public GameObject playerCam;

    void Start ()
    {
        playerCam = Camera.main.gameObject;

        curHealth = maxHealth;
        curStamina = maxStamina;
        curMana = maxMana;
	}
	
	void Update ()
    {
		
	}
}
