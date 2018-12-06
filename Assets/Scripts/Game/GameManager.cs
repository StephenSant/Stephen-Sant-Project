using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System;

public class GameSave
{
    public Vector3 playerPos;
}

public class GameManager : MonoBehaviour
{
    #region Variables
    #region KeyCodes
    public static KeyCode forward, backward, left, right, jump, interact, inventory, leftHand, rightHand, run;
    #endregion
    #region Save & Load
    private OptionPrefs optionsData = new OptionPrefs();
    private GameSave gamedata = new GameSave();
    public string[] fileName = new string[] { "OptionPrefs", "GameSave" };
    #endregion
    #region References
    [Header("References")]
    public GameObject player;
    #endregion
    #region Stats
    public int strength;
    public int dexterity;
    public int constatution;
    public int intelligence;
    public int wisdom;
    public int charisma;
    #endregion
    #endregion
    //Singleton
    public static GameManager GM;
    private void Awake()
    {
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
    private void OnDestroy()
    {
        GM = null;
    }

    private void Start()
    {
        #region Options
        //Finding and opening the xml file
        var serializer0 = new XmlSerializer(typeof(OptionPrefs));
        using (var stream = new FileStream(Application.persistentDataPath + "/" + fileName[0] + ".xml", FileMode.Open))
        {
            optionsData = serializer0.Deserialize(stream) as OptionPrefs;
        }
        #region Getting keys
        forward = optionsData.forward;
        backward = optionsData.backward;
        left = optionsData.left;
        right = optionsData.right;
        jump = optionsData.jump;
        interact = optionsData.interact;
        inventory = optionsData.inventory;
        run = optionsData.run;
        #endregion
        #endregion
        
        LoadGame();
    }

    public void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/" + fileName[1] + ".xml";
        if (File.Exists(filePath))
        {
            var serializer = new XmlSerializer(typeof(GameSave));
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                gamedata = serializer.Deserialize(stream) as GameSave;
            }
            player.transform.position = gamedata.playerPos;
        }
    }

    public void SaveGame()
    {
        string filePath = Application.persistentDataPath + "/" + fileName[1] + ".xml";

        gamedata.playerPos = player.transform.position;

        var serializer = new XmlSerializer(typeof(GameSave));
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, gamedata);
        }
    }

}
