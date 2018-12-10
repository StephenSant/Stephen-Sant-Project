using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 1;
    [HideInInspector]
    public float curHealth;

    // Use this for initialization
    void Start ()
    {
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name+" has died.");
        }  
	}

    private void OnDestroy()
    {
        GameObject clone = Instantiate(Resources.Load("Prefabs/Items/" + ItemData.CreateItem(402).MeshName),GetComponentInChildren<MeshRenderer>().transform.position, GetComponentInChildren<MeshRenderer>().transform.rotation) as GameObject;
        clone.AddComponent<Rigidbody>().useGravity = true;
    }
}
