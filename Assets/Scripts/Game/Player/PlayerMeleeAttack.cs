using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float damage;
    public float range = 2;

    public Transform playerCamera;
    public PlayerHandler handler;
    public Inventory inventory;

    private Item currentWeapon;

    // Use this for initialization
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>().transform;
        handler = GetComponent<PlayerHandler>();
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.weaponInfo != null)
        {
            if (currentWeapon != inventory.weaponInfo)
            {
                currentWeapon = inventory.weaponInfo;
                damage = inventory.weaponInfo.Damage + handler.strength;
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.TransformDirection(Vector3.forward) * range, out hit))
            {
                if (hit.transform.tag == "Enemy" && hit.distance <= range)
                {
                    hit.transform.GetComponent<EnemyHealth>().curHealth -= damage;
                    Debug.Log("You hit a " + hit.transform.name + " with " + damage +" points of damage!");
                }
            }

        }
    }
}
