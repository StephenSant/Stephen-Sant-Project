using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public GameObject player;

    public Item[] items;

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
    }

    // Update is called once per frame
    void Update()
    {

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
            GUI.Box(new Rect(0, scr.y * 4.5f, scr.x * 16, scr.y * 4.5f), "");

            //for (float a = 0; a < 3; a += 1.5f)
            //{

            //    for (int b = 0; b < 3; b++)
            //    {
            //        if (GUI.Button(new Rect(scr.x * a + (scr.x * 2), scr.y * (4 + b), scr.x * 1.5f, scr.y), "Item " + b))
            //        {


            //        }
            //    }
            //}
            int i = 0;
            for (int a = 1; a <= 3; a++)
            {
                switch (a)
                {
                    case 1:
                        for (int b = 1; b <= 3; b++)
                        {
                            if (GUI.Button(new Rect(scr.x * a , scr.y *  b , scr.x * 1.5f, scr.y), "Item " + i))
                            {


                            }
                            i++;
                        }
                        break;


                    case 2:

                        for (int b = 1; b <= 3; b++)
                        {
                            if (GUI.Button(new Rect(scr.x * a , scr.y * b , scr.x * 1.5f, scr.y), "Item " + i))
                            {


                            }
                            i++;
                        }
                        break;
                    case 3:

                        for (int b = 1; b <= 3; b++)
                        {
                            if (GUI.Button(new Rect(scr.x * a , scr.y * b , scr.x * 1.5f, scr.y), "Item " + i))
                            {


                            }
                            i++;
                        }
                        break;
                }
            }


            if (GUI.Button(new Rect(scr.x * 10, scr.y * 5, scr.x * 1, scr.y * 0.5f), "Buy"))
            {
                Debug.Log("");
            }
            if (GUI.Button(new Rect(scr.x * 14, scr.y * 8, scr.x * 2, scr.y), "Exit"))
            {
                ToggleShopScreen();
            }
        }
    }
}
