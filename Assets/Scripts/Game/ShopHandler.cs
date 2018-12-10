using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public GameObject player;
    public List<Item> items = new List<Item>();

    [Header("Styles")]
    public GUIStyle buttonStyle;
    public GUIStyle iconStyle;
    public GUIStyle textStyle;
    public GUIStyle backgroundStyle;

    private Item selectedItem;
    private int selectedItemIndex;
    private bool UIOn = false;
    int i;

    public bool ToggleShopScreen()
    {
        //closes the shop
        if (UIOn)
        {
            UIOn = false;
            PlayerUI.Freeze();
            return false;
        }
        //opens the shop
        else
        {
            UIOn = true;
            PlayerUI.Freeze();
            return true;
        }

    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        items.Add(ItemData.CreateItem(0));
        items[0].Amount = 10;

    }

    private void OnGUI()
    {
        //screen scaling
        Vector2 scr = Vector2.zero;
        if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
        if (UIOn)
        {
            GUI.Box(new Rect(0, scr.y * 4.5f, scr.x * 16, scr.y * 4.5f), "", backgroundStyle);
            #region Shows the items
            int i = 0;
            for (int a = 1; a <= 4; a++)
            {
                switch (a)
                {
                    case 1:

                        for (int b = 1; b <= 3; b++)
                        {
                            if (i < items.Count)
                            {
                                if (GUI.Button(new Rect(scr.x * a, (scr.y * b) + (4f * scr.y), scr.x * 1f, scr.y), items[i].Name, buttonStyle))
                                {
                                    selectedItem = items[i];
                                    selectedItemIndex = i;
                                }

                            }
                            i++;
                        }
                        break;


                    case 2:

                        for (int b = 1; b <= 3; b++)
                        {
                            if (i < items.Count)
                            {
                                if (GUI.Button(new Rect(scr.x * a, (scr.y * b) + (4f * scr.y), scr.x * 1f, scr.y), items[i].Name, buttonStyle))
                                {
                                    selectedItem = items[i];
                                    selectedItemIndex = i;
                                }

                            }
                            i++;
                        }
                        break;
                    case 3:

                        for (int b = 1; b <= 3; b++)
                        {
                            if (i < items.Count)
                            {

                                if (GUI.Button(new Rect(scr.x * a, (scr.y * b) + (4f * scr.y), scr.x * 1f, scr.y), items[i].Name, buttonStyle))
                                {
                                    selectedItem = items[i];
                                    selectedItemIndex = i;
                                }

                            }
                            i++;
                        }
                        break;

                    case 4:

                        for (int b = 1; b <= 3; b++)
                        {

                            if (i < items.Count)
                            {
                                if (GUI.Button(new Rect(scr.x * a, (scr.y * b) + (4f * scr.y), scr.x * 1f, scr.y), items[i].Name, buttonStyle))
                                {
                                    selectedItem = items[i];
                                    selectedItemIndex = i;
                                }

                            }
                            i++;
                        }
                        break;
                }
            }
            #endregion
            if (selectedItem != null)
            {
                if (Inventory.money >= selectedItem.Value)
                {
                    if (GUI.Button(new Rect(scr.x * 5.5f, scr.y * 6, scr.x * 1, scr.y * 0.5f), "Buy", buttonStyle))
                    {
                        if (selectedItem != null)
                        {
                            if (selectedItem.Amount > 1)
                            {
                                if (selectedItem.Type == ItemTypes.Craftable || selectedItem.Type == ItemTypes.Consumables)
                                {
                                    int found = 0;
                                    int addIndex = 0;
                                    for (int c = 0; c < Inventory.inv.Count; c++)
                                    {
                                        if (selectedItem.Id == Inventory.inv[c].Id)
                                        {
                                            found = 1;
                                            addIndex = c;
                                            break;
                                        }
                                    }
                                    if (found == 1)
                                    {
                                        Inventory.inv[addIndex].Amount++;

                                    }
                                    else
                                    {
                                        Inventory.inv.Add(ItemData.CreateItem(selectedItem.Id));
                                    }
                                }
                                else
                                {
                                    Inventory.inv.Add(selectedItem);
                                }
                                items[selectedItemIndex].Amount--;
                                Inventory.money -= selectedItem.Value;
                            }
                            else
                            {
                                items.Remove(selectedItem);
                                selectedItem = null;
                            }


                        }
                    }
                }
                else
                {
                    GUI.Box(new Rect(scr.x * 5.5f, scr.y * 6, scr.x * 1, scr.y * 0.5f), "Can't afford.", buttonStyle);
                }

                GUI.Box(new Rect(scr.x * 7f, scr.y * 5, scr.x * 2, scr.y * 2f), selectedItem.Icon, iconStyle);
                GUI.Box(new Rect(scr.x * 9.5f, scr.y * 5, scr.x * 4, scr.y * 2f), selectedItem.Description, textStyle);
                GUI.Box(new Rect(7 * scr.x, 7f * scr.y, 2 * scr.x, 0.75f * scr.y), "Cost: " + selectedItem.Value, textStyle);
                GUI.Box(new Rect(9 * scr.x, 7f * scr.y, 2 * scr.x, 0.75f * scr.y), "Your money: " + Inventory.money, textStyle);
            }
            else
            {
                GUI.Box(new Rect(scr.x * 7f, scr.y * 5, scr.x * 2, scr.y * 2f), "", iconStyle);
                GUI.Box(new Rect(scr.x * 9.5f, scr.y * 5, scr.x * 4, scr.y * 2f), "", textStyle);
                GUI.Box(new Rect(7 * scr.x, 7f * scr.y, 2 * scr.x, 0.75f * scr.y), "Cost: ", textStyle);
                GUI.Box(new Rect(9 * scr.x, 7f * scr.y, 2 * scr.x, 0.75f * scr.y), "Your money: " + Inventory.money, textStyle);
            }

            if (GUI.Button(new Rect(scr.x * 13.5f, scr.y * 7.75f, scr.x * 2, scr.y), "Exit", buttonStyle))
            {
                ToggleShopScreen();
            }
        }
    }
}
