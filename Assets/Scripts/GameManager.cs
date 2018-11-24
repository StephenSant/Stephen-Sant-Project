using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System;

public class  GameManager : MonoBehaviour
{
    #region Variables
    #region KeyCodes
    public static KeyCode forward, backward, left, right, jump, crouch, interact, inventory, leftHand, rightHand, run;
    #endregion
    private OptionPrefs data = new OptionPrefs();
    public string fileName = "OptionPrefs";
    #endregion

    public int strenght;
    public int dexterity;
    public int constatution;
    public int intelligence;
    public int wisdom;
    public int charisma;

    //Singleton
    public static GameManager GM;
    private void Awake()
    {
        //Finding and opening the xml file
		var serializer = new XmlSerializer(typeof(OptionPrefs));
        using (var stream = new FileStream(Application.persistentDataPath + "/" + fileName + ".xml", FileMode.Open))
        {
            data = serializer.Deserialize(stream) as OptionPrefs;
        }
        //if the game manager does exist, then make this the game manger and dont destroy it though the changing of scenes
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        //if a game manager already exist then it will destory itself
        else if (GM != this)
        {
            Destroy(gameObject);
        }   
    }
    

    // Use this for initialization
    void Start ()
    {   

        #region Getting keys
        forward = data.forward;
        backward = data.backward;
        left = data.left;
        right = data.right;
        jump = data.jump;
        crouch = data.crouch;
        interact = data.interact;
        inventory = data.inventory;
        run = data.run;
        #endregion
    }

    // Update is called once per frame
    void Update () {
		
	}
}
