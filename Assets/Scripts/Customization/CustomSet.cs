using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;
using System.IO;
public class CharacterPrefs
    {
    public int skin;
    public int hair;
    public int clothes;
    public string charName;
    }

public class CustomSet : MonoBehaviour
{
    
    [Header("Texture List")]//Texture2D List for skin, hair and eyes
    public List<Material> skin = new List<Material>();
    public List<Material> hair = new List<Material>();
    public List<Material> clothes = new List<Material>();

    [Header("Index")]//index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex;
    public int clothesIndex;

    [Header("Renderer")]//renderer for our character mesh so we can reference a material list
    public Renderer skinMesh;
    public Renderer hairMesh;
    public Renderer clothesMesh;
    

    [Header("Max Index")]//max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax;
    public int clothesMax;

    [Header("Character Name")]//name of our character that the user is making
    public string charName = "John";

    [Header("Game Saves")]
    public string fileName = "CharacterPrefs";
    private CharacterPrefs characterData = new CharacterPrefs();
    private string fullPath;

    [Header("Stats")]
    [Range(1, 10)]
    public int strength = 0;
    [Range(1, 10)]
    public int dexterity = 0, constitution = 0, inteligence = 0, wisdom =0, charisma = 0;
    public int points = 8;
    public int baseAmout = 0;

    private void Awake()
    {
        fileName = "CharacterPrefs";
        fullPath = Application.persistentDataPath + "/" + fileName + ".xml";
    }

    // Use this for initialization
    void Start ()
    {
        strength = 0;
        dexterity = 0;
        constitution = 0;
        inteligence = 0;
        wisdom = 0;
        charisma = 0;
        #region Pulling the Textures from the file
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temperary Texture2D that it from the Resources File looking for Skin_(number)
            Material temp = Resources.Load("Character/Skin_" + i) as Material;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        for (int i = 0; i < hairMax ; i++)
        {
            //creating a temperary Texture2D that it from the Resources File looking for Skin_(number)
            Material temp = Resources.Load("Character/Hair_" + i) as Material;
            //add our temp texture that we just found to the skin List
            hair.Add(temp);
        }
        for (int i = 0; i < clothesMax ; i++)
        {
            //creating a temperary Texture2D that it from the Resources File looking for Skin_(number)
            Material temp = Resources.Load("Character/Clothes_" + i) as Material;
            //add our temp texture that we just found to the skin List
            clothes.Add(temp);
        }
        #endregion
    }

    void SetTexture(string type, int dir)
    {
        int index = 0, max = 0;
        Material[] textures = new Material[0];
        Renderer mesh = skinMesh;
        #region Switch Material
        switch (type)
        {
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material
                mesh = skinMesh;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                mesh = hairMesh;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                mesh = clothesMesh;
                break;
        }
        #endregion
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }

        #region Set Material Switch
        switch (type)
        {
            case "Skin":
                Material[] skinMat = skinMesh.materials;
        skinMat[0] = textures[index];
        skinMesh.materials = skinMat;
                //skin index equals our index
                skinIndex = index;
                break;
            case "Hair":
                Material[] hairMat = hairMesh.materials;
        hairMat[0] = textures[index];
        hairMesh.materials = hairMat;
                hairIndex = index;
                break;
            case "Clothes":
                Material[] clothesMat = clothesMesh.materials;
        clothesMat[0] = textures[index];
        clothesMesh.materials = clothesMat;
                clothesIndex = index;
                
                break;

        }
        #endregion

    }
    private void OnGUI()
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        float scrW = Screen.width / 16,
            scrH = Screen.height / 9;
        #region Customisation
        int i = 0;
        GUI.Box(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 2f * scrW, 0.5f * scrH), "Customisation");

        //create an int that will help with shuffling your GUI elements under eachother
        i++;
        #region Skin
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1 
            SetTexture("Skin", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Skin");

        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            SetTexture("Skin", 1);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        #endregion
        //set up same things for Hair, Mouth and Eyes
        #region Hair
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {

            SetTexture("Hair", -1);
        }
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Hair");
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Hair", 1);
        }
        i++;
        #endregion
        
        
        #region Clothes
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {

            SetTexture("Clothes", -1);
        }
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Clothes");
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Clothes", 1);
        }
        i++;
        #endregion
        #endregion
        #region Random Reset
        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
        {
            SetTexture("Skin", UnityEngine.Random.Range(0, skinMax - 1));
            SetTexture("Hair", UnityEngine.Random.Range(0, hairMax - 1));
            SetTexture("Clothes", UnityEngine.Random.Range(0, clothesMax - 1));
        }
        //reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.5f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        
        #region Skills
        i = 0;
        GUI.Box(new Rect(4.1f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Skills:");
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (strength != baseAmout)
            {
                strength--;
                points++;
                if (strength <= baseAmout)
                {
                    strength = baseAmout;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Strength = " + strength);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (strength != 10 && points != baseAmout)
            {
                strength++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (dexterity != baseAmout)
            {
                dexterity--;
                points++;
                if (dexterity <= baseAmout)
                {
                    dexterity = baseAmout;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Dexterity = " + dexterity);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (dexterity != 10 && points != baseAmout)
            {
                dexterity++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (constitution != baseAmout)
            {
                constitution--;
                points++;
                if (constitution <= baseAmout)
                {
                    constitution = baseAmout;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Constitution = " + constitution);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (constitution != 10 && points != baseAmout)
            {
                constitution++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (inteligence != baseAmout)
            {
                inteligence--;
                points++;
                if (inteligence <= baseAmout)
                {
                    inteligence = baseAmout;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Inteligence = " + inteligence);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (inteligence != 10 && points != baseAmout)
            {
                inteligence++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (wisdom != baseAmout)
            {
                wisdom--;
                points++;
                if (wisdom <= baseAmout)
                {
                    wisdom = baseAmout;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Wisdom = " + wisdom);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (wisdom != 10 && points != baseAmout)
            {
                wisdom++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (charisma != baseAmout)
            {
                charisma--;
                points++;
                if (charisma <= baseAmout)
                {
                    charisma = baseAmout;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Chariama = " + charisma);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (charisma != 10 && points != baseAmout)
            {
                charisma++;
                points--;
            }
        }
        i++;
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Points: " + points);
        #endregion
        #region Character Name and Save & Play
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        charName = GUI.TextField(new Rect(10.25f * scrW, 1.5f * scrH, 1.75f * scrW, .35f * scrH), charName, 16);
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //GUI Button called Save and Play
        if (GUI.Button(new Rect(13.75f * scrW, scrH * 4.75f, 2 * scrW, 0.5f * scrH), "Save and Play") && points == 0)
        {
            //this button will run the save function and also load into the game scene
            Save();
            SceneManager.LoadScene(2);
        }
        if (points != 0)
        {
            GUI.Box(new Rect(13.6f * scrW, scrH * 5.5f, 2.3f * scrW, .75f * scrH), "All points must be\nspent before continuing!");
        }
        #endregion
        if (GUI.Button(new Rect(13.75f * scrW, scrH * 4f, 2 * scrW, 0.5f * scrH), "Back"))
        {
            SceneManager.LoadScene(0);
        }
    }
    void Save()//Function called Save this will allow us to save our indexes to PlayerPrefs
    {
        characterData.hair = hairIndex;
        characterData.skin = skinIndex;
        characterData.clothes = clothesIndex;
        characterData.charName = charName;
        var serializer = new XmlSerializer(typeof(CharacterPrefs));
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            serializer.Serialize(stream, characterData);
            
        }
    }
}