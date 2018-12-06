using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<Item> inv = new List<Item>();

    public Item selectedItem;
    public static int money;

    public string sortType = "All";

    public Transform dropLocation;
    public Transform[] equippedLocation;
    public GameObject curWeapon;
    public Item weaponInfo;
    public GameObject curHelm;

    private static bool showInv;
    private PlayerHandler handler;
    private Vector2 scr = Vector2.zero;
    private Vector2 scrollPos = Vector2.zero;

    public GUIStyle backgroundStyle;
    public GUIStyle iconStyle;
    public GUIStyle buttonStyle;
    public GUIStyle itemStyle;
    public GUIStyle infoStyle;

    private void Start()
    {
        handler = GetComponent<PlayerHandler>();

        inv.Add(ItemData.CreateItem(0));


    }

    public static bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            PlayerUI.Freeze();
            return (false);
        }
        else
        {
            showInv = true;
            PlayerUI.Freeze();
            return (true);
        }
    }
    private void OnGUI()
    {

        if (showInv)
        {
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory", backgroundStyle);

            if (GUI.Button(new Rect(scr.x * 0.5f, scr.y * .6f, scr.x * 1.25f, scr.y * .5f), "All", buttonStyle))
            {
                sortType = "All";
            }
            if (GUI.Button(new Rect(scr.x * 0.5f, scr.y * 1.1f, scr.x * 1.25f, scr.y * .5f), "Consumables", buttonStyle))
            {
                sortType = "Consumables";
            }
            if (GUI.Button(new Rect(scr.x * 0.5f, scr.y * 1.6f, scr.x * 1.25f, scr.y * .5f), "Armour", buttonStyle))
            {
                sortType = "Armour";
            }
            if (GUI.Button(new Rect(scr.x * 0.5f, scr.y * 2.1f, scr.x * 1.25f, scr.y * .5f), "Craftable", buttonStyle))
            {
                sortType = "Craftable";
            }
            if (GUI.Button(new Rect(scr.x * 0.5f, scr.y * 2.6f, scr.x * 1.25f, scr.y * .5f), "Weapon", buttonStyle))
            {
                sortType = "Weapon";
            }
            if (GUI.Button(new Rect(scr.x * 0.5f, scr.y * 3.1f, scr.x * 1.25f, scr.y * .5f), "Misc", buttonStyle))
            {
                sortType = "Misc";
            }

            DisplayInv(sortType);

            if (weaponInfo != null)
            {
                GUI.Box(new Rect(12.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), weaponInfo.Icon);
            }
            else
            {
                GUI.Box(new Rect(12.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), "Currently not holding anything.", iconStyle);
            }

            if (selectedItem != null)
            {
                GUI.Box(new Rect(5.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon, iconStyle);
                switch (selectedItem.Type)
                {
                    case ItemTypes.Consumables:
                        GUI.Box(new Rect(5.5f * scr.x, 3.75f * scr.y, 5 * scr.x, 2 * scr.y), selectedItem.Description + "\n\nAmount: " + selectedItem.Amount + "\nValue: " + selectedItem.Value + "\nHealth: " + selectedItem.Heal, infoStyle);
                        if (handler.curHealth < handler.maxHealth)
                        {
                            if (GUI.Button(new Rect(6.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Use", buttonStyle))
                            {
                                handler.curHealth += selectedItem.Heal;
                                if (selectedItem.Amount > 1)
                                {
                                    selectedItem.Amount--;
                                }
                                else
                                {
                                    inv.Remove(selectedItem);
                                    selectedItem = null;
                                }
                                return;
                            }
                        }

                        else if (selectedItem.Heal < 0)
                        {
                            if (GUI.Button(new Rect(6.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Use", buttonStyle))
                            {
                                handler.curHealth += selectedItem.Heal;
                                inv.Remove(selectedItem);
                                selectedItem = null;
                                return;
                            }
                        }
                        else
                        {
                            GUI.Box(new Rect(6.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Use", buttonStyle);
                        }

                        break;
                    case ItemTypes.Armour:
                        GUI.Box(new Rect(5.5f * scr.x, 3.75f * scr.y, 5 * scr.x, 2 * scr.y), selectedItem.Description + "\n\nValue: " + selectedItem.Value + "\nArmour: " + selectedItem.Armour, infoStyle);
                        if (GUI.Button(new Rect(6.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Equip", buttonStyle))
                        {

                        }
                        break;
                    case ItemTypes.Craftable:
                        GUI.Box(new Rect(5.5f * scr.x, 3.75f * scr.y, 5 * scr.x, 2 * scr.y), selectedItem.Description + "\n\nAmount: " + selectedItem.Amount + "\nValue: " + selectedItem.Value, infoStyle);
                        break;
                    case ItemTypes.Misc:
                        GUI.Box(new Rect(5.5f * scr.x, 3.75f * scr.y, 5 * scr.x, 2 * scr.y), selectedItem.Description + "\n\nValue: " + selectedItem.Value, infoStyle);
                        if (GUI.Button(new Rect(6.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Use", buttonStyle))
                        {

                        }
                        break;
                    case ItemTypes.Weapon:
                        GUI.Box(new Rect(5.5f * scr.x, 3.75f * scr.y, 5 * scr.x, 2 * scr.y), selectedItem.Description + "\n\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage, infoStyle);

                        if (curWeapon == null || selectedItem.MeshName != curWeapon.name)
                        {
                            if (GUI.Button(new Rect(6.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Equip", buttonStyle))
                            {
                                weaponInfo = selectedItem;
                                if (curWeapon != null)
                                {
                                    Destroy(curWeapon);
                                }
                            }
                        }
                        else if (curWeapon != null)
                        {
                            if (GUI.Button(new Rect(6.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Unequip", buttonStyle))
                            {
                                Destroy(curWeapon);
                                weaponInfo = null;
                            }
                        }
                        break;
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 5.75f * scr.y, 1 * scr.x, 0.5f * scr.y), "Discard", buttonStyle))
                {

                    if (curWeapon != null && selectedItem.MeshName == curWeapon.name)
                    {
                        Destroy(curWeapon);
                        weaponInfo = null;
                    }
                    else if (curHelm != null && selectedItem.MeshName == curHelm.name)
                    {
                        Destroy(curHelm);
                    }

                    GameObject clone = Instantiate(Resources.Load("Prefabs/Items/" + selectedItem.MeshName) as GameObject, dropLocation.position, Quaternion.identity);
                    clone.AddComponent<Rigidbody>().useGravity = true;
                    if (selectedItem.Amount > 1)
                    {
                        selectedItem.Amount--;
                    }
                    else
                    {
                        inv.Remove(selectedItem);
                        selectedItem = null;
                    }
                    return;



                }
            }
            else
            {
                GUI.Box(new Rect(5.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), "", iconStyle);
                GUI.Box(new Rect(5.5f * scr.x, 3.75f * scr.y, 5 * scr.x, 2 * scr.y), "", infoStyle);
            }
        }

    }
    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))//this displays the selected sort type
        {
            ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
            int a = 0;//amout of that type
            int s = 0;//slot postion of UI item
            for (int i = 0; i < inv.Count; i++)//this will make 'a' = the amount of items of that type in the inventory 
            {
                if (inv[i].Type == type)
                {
                    a++;
                }

            }
            if (a <= 15)//if the amount of this type is able to fit on the screen
            {
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory 
                {
                    if (inv[i].Type == type)
                    {
                        if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                        {
                            if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + s * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount, itemStyle))
                            {
                                selectedItem = inv[i];
                                Debug.Log(selectedItem.Name);
                            }
                        }
                        else
                        {
                            if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + s * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name, itemStyle))
                            {
                                selectedItem = inv[i];
                                Debug.Log(selectedItem.Name);
                            }
                        }
                        s++;//move down 1 position
                    }
                }

            }
            else//if the amount of this type is NOT able to fit on the screen
            {
                scrollPos = GUI.BeginScrollView(new Rect(-1f * scr.x, scr.y, 6 * scr.x, 7.5f * scr.y), scrollPos, new Rect(0, 0, 0, (8.5f * scr.y) + ((a - 17) * (0.5f * scr.y))), false, true);
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory
                {
                    if (inv[i].Type == type)
                    {
                        if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                        {
                            if (GUI.Button(new Rect(3 * scr.x, s * (0.5f * scr.y), 2.75f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount, itemStyle))
                            {
                                selectedItem = inv[i];
                            }
                        }
                        else
                        {
                            if (GUI.Button(new Rect(3 * scr.x, s * (0.5f * scr.y), 2.75f * scr.x, 0.5f * scr.y), inv[i].Name, itemStyle))
                            {
                                selectedItem = inv[i];
                            }
                        }
                        s++;
                    }
                }
                GUI.EndScrollView();
            }
        }
        else//this displays all items
        {
            #region Non Scroll Inventory
            if (inv.Count <= 15)
            {
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory
                {
                    if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                    {
                        if (GUI.Button(new Rect(2 * scr.x, 1 * scr.y + i * (0.5f * scr.y), 2.75f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount, itemStyle))
                        {
                            selectedItem = inv[i];
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(2 * scr.x, 01 * scr.y + i * (0.5f * scr.y), 2.75f * scr.x, 0.5f * scr.y), inv[i].Name, itemStyle))
                        {
                            selectedItem = inv[i];
                        }
                    }
                }
            }
            #endregion
            #region Scroll Inventory
            else
            {
                //our pos in scrolling view window, current pos, the viewable area, can you see the horizontal bar and can you see the vertical bar 
                scrollPos = GUI.BeginScrollView(new Rect(-1f * scr.x, scr.y, 6 * scr.x, 7.5f * scr.y), scrollPos, new Rect(0, 0, 0, (8.5f * scr.y) + ((inv.Count - 17) * (0.5f * scr.y))), false, true);
                #region Items in the viewing area
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory
                {
                    if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                    {
                        if (GUI.Button(new Rect(3 * scr.x, i * (0.5f * scr.y), 2.75f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount, itemStyle))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(3 * scr.x, i * (0.5f * scr.y), 2.75f * scr.x, 0.5f * scr.y), inv[i].Name, itemStyle))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                }
                #endregion
                //the end of our viewing area
                GUI.EndScrollView();
            }
            #endregion
        }
    }

}



