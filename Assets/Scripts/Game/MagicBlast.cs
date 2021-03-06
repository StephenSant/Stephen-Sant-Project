﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlast : MonoBehaviour
{
    public float speed;
    public float damage = 15;
    public float range;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<EnemyHealth>() == null)
            {
                Debug.LogError("" + other.name + " has no health script!");
            }
            else
            {
                other.GetComponent<EnemyHealth>().curHealth -= damage;

                other.transform.GetComponent<EnemyHealth>().curHealth -= damage;
                Debug.Log("You hit a " + other.transform.name + " with " + damage + " points of damage!");

            }

        }
        Destroy(gameObject);
    }
}