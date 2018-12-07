using System.Collections;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale != 0)
        {
            Ray interact;
            interact = GameObject.FindGameObjectWithTag("POVCam").GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                    if (handler != null)
                    {
                        handler.OnCollection();
                    }
                    else
                    {
                        Debug.LogError("This has no Item Handler script!");
                    }
                }
                #endregion
            }
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region Item
                if (hitInfo.collider.CompareTag("Shop"))
                {
                    ShopHandler handler = hitInfo.transform.GetComponent<ShopHandler>();
                    if (handler != null)
                    {
                        handler.ToggleShopScreen();
                    }
                    else
                    {
                        Debug.LogError("This has no Shop Handler script!");
                    }
                }
                #endregion
            }
        }
    }
}