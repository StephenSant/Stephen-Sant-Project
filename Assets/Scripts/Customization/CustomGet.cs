using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class CustomGet : MonoBehaviour
{
    [Header("Renderer")]//renderer for our character mesh so we can reference a material list
    public Renderer skinMesh;
    public Renderer hairMesh;
    public Renderer clothesMesh;

    private CharacterPrefs data = new CharacterPrefs();
    private string fileName = "CharacterPrefs";

    // Use this for initialization
    void Start()
    {
        LoadTexture();
    }
    void LoadTexture()
    {
        //Finding and opening the xml file
        var serializer = new XmlSerializer(typeof(CharacterPrefs));
        using (var stream = new FileStream(Application.persistentDataPath + "/" + fileName + ".xml", FileMode.Open))
        {
            data = serializer.Deserialize(stream) as CharacterPrefs;
        }
        SetTexture("Skin", data.skin);
        SetTexture("Hair", data.hair);
        SetTexture("Clothes", data.clothes);
    }


    void SetTexture(string type, int index)
    {

        switch (type)
        {
            case "Skin":
                skinMesh.material = Resources.Load("Character/Skin_" + index.ToString()) as Material;
                break;
            case "Hair":
                hairMesh.material = Resources.Load("Character/Hair_" + index.ToString()) as Material;
                break;
            case "Clothes":
                clothesMesh.material = Resources.Load("Character/Clothes_" + index.ToString()) as Material;
                break;
        }
    }
}
