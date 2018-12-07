using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHandler))]
public class PlayerMagicAttack : MonoBehaviour
{
    public GameObject particle;
    public Transform firePoint;

    public float manaUsed = 5;

    // Update is called once per frame
    void Update()
    {
        PlayerHandler handler = GetComponent<PlayerHandler>();
        if (Input.GetMouseButtonDown(1)&& handler.curMana > manaUsed&&Time.timeScale!=0)
        {
            Instantiate(particle, firePoint.position, firePoint.rotation, null);
            handler.curMana -= manaUsed;
        }
        
    }
}
