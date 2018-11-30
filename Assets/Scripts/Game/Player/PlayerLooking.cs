using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    [Header("Variables")]
    public Vector2 sensitivity = new Vector2(25f, 10);
    public Vector2 limits = new Vector2(-85, 85); // X=Max | Y=Min
    public Transform cam;
    public static bool isFrozen;
    float YRot;

    
    // Use this for initialization
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("POVCam").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime != 0)
        {
            transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * sensitivity.x));

            YRot += (Input.GetAxis("Mouse Y") * sensitivity.y);
            YRot = Mathf.Clamp(YRot, limits.x, limits.y);
            cam.localEulerAngles = new Vector3(-YRot, 0, 0);
        }
    }

    public static bool Freeze()
    {
        if (isFrozen)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isFrozen = false;

        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isFrozen = true;

        }
        return isFrozen;

    }
}
