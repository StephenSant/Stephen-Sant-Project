using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float damage = 2;
    public float range = 2;

    public Transform playerCamera;

    // Use this for initialization
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.TransformDirection(Vector3.forward) * range, out hit))
            {
                if (hit.transform.tag == "Enemy"&&hit.distance <= range)
                {
                    hit.transform.GetComponent<EnemyHealth>().curHealth -= damage;
                    Debug.Log("You hit a " + hit.transform.name + "!");
                }
            }

        }
        Debug.DrawRay(playerCamera.position, playerCamera.TransformDirection(Vector3.forward) * range, Color.yellow);
    }
}
