using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public static int money;

    public Transform[] equippedLocation;
    public GameObject curWeapon;
    public Item weaponInfo;
    public GameObject curHelm;

    void Start()
    {

    }

    private void OnGUI()
    {
        Vector2 scr = Vector2.zero;
        if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
        if (showInv)
        {
            
        }
		
	}
}
