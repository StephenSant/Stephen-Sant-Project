using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System;
public class OptionPrefs
{
    public float volume;
    public Vector2 resolution;
}

public class OptionsHandler : MonoBehaviour
{
    public float volume;
    public Vector2[] res = new Vector2[7];
    public int resIndex;
    public bool isFullScreen = true;
    public List<KeyCode> keysBinds;

    [Header("References")]
    public Slider volSlider;
    public Dropdown resDropdown;
    public Toggle windowedToggle;
    public List<Button> keyBindButton;

    [Header("Game Saves")]
    public string fileName = "OptionPrefs";
    private OptionPrefs optionsData = new OptionPrefs();
    private string fullPath;

    private void Awake()
    {
        fullPath = Application.dataPath + "/GameData/" + fileName + ".xml";
    }

    private void Start()
    {
        volSlider.value = volume;
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y,!isFullScreen);
    }

    private void Update()
    {
        volume = volSlider.value;
    }
    public void Resolution()
    {
        resIndex = resDropdown.value;
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullScreen);
    }
    public void Windowed()
    {
        isFullScreen = windowedToggle.isOn;
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullScreen);
    }
    public void SetKeyBinds()
    {

    }
    public void SavePrefs()
    {
        optionsData.volume = volume;
        optionsData.resolution = res[resIndex];
        var serializer = new XmlSerializer(typeof(OptionPrefs));
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            serializer.Serialize(stream, optionsData);
        }
    }
}
