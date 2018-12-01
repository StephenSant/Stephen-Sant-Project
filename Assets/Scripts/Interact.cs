using System.Collections;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
                }
                #endregion
            }
        }
    }
}