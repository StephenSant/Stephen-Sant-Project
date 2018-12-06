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
    public bool isFullScreen;
    public KeyCode forward, backward, left, right, jump, crouch, interact, inventory, run;
}

public class OptionsHandler : MonoBehaviour
{
    #region Variables
    #region Audio
    public float volume;
    #endregion
    #region Visual
    public Vector2[] res = new Vector2[7];
    public int resIndex = 6;
    public bool isFullScreen = true;
    #endregion
    #region Keys
    public KeyCode forward, backward, left, right, jump, crouch, interact, inventory, run;
    Event keyEvent;
    public KeyCode newKey;
    public string assignKey;
    public Text forwardText, backwardText, leftText, rightText, jumpText, crouchText, interactText, inventoryText, runText;
    public string forwardButton, backwardButton, leftButton, rightButton, jumpButton, crouchButton, interactButton, inventoryButton, runButton;
    public bool waitingForKey;
    #endregion
    #region References
    [Header("References")]
    public Slider volSlider;
    public Dropdown resDropdown;
    public Toggle windowedToggle;
    #endregion
    #region Game Saves
    [Header("Game Saves")]
    private OptionPrefs optionsData = new OptionPrefs();
    private string fileName = "OptionPrefs";
    #endregion
    #endregion

    private void Start()
    {
        
        #region Set keys to defaults
        if (forward == KeyCode.None)
        {
            forward = KeyCode.W;
        }
        if (backward == KeyCode.None)
        {
            backward = KeyCode.S;
        }
        if (left == KeyCode.None)
        {
            left = KeyCode.A;
        }
        if (right == KeyCode.None)
        {
            right = KeyCode.D;
        }
        if (jump == KeyCode.None)
        {
            jump = KeyCode.Space;
        }
        if (crouch == KeyCode.None)
        {
            crouch = KeyCode.LeftControl;
        }
        if (run == KeyCode.None)
        {
            run = KeyCode.LeftShift;
        }
        if (interact == KeyCode.None)
        {
            interact = KeyCode.E;
        }
        if (inventory == KeyCode.None)
        {
            inventory = KeyCode.Tab;
        }
        #endregion


        var serializer = new XmlSerializer(typeof(OptionPrefs));
        using (var stream = new FileStream(Application.persistentDataPath + "/" + fileName + ".xml", FileMode.Open))
        {
            optionsData = serializer.Deserialize(stream) as OptionPrefs;
        }

        if (optionsData.resolution != Vector2.zero)
        {
            Screen.SetResolution((int)optionsData.resolution.x, (int)optionsData.resolution.y, optionsData.isFullScreen);
        }



        volSlider.value = volume;
        waitingForKey = false;
        forwardButton = "forward";
        backwardButton = "backward";
        leftButton = "left";
        rightButton = "right";
        jumpButton = "jump";
        interactButton = "interact";
        inventoryButton = "inventory";
        runButton = "run";


    }

    private void OnGUI()
    {
        //Getting a key for the key binding
        keyEvent = Event.current;
        if (waitingForKey && keyEvent.isKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    private void Update()
    {
        volume = volSlider.value;
        #region Writes the key on to the button
        forwardText.text = forward.ToString();
        backwardText.text = backward.ToString();
        leftText.text = left.ToString();
        rightText.text = right.ToString();
        jumpText.text = jump.ToString();
        runText.text = run.ToString();
        inventoryText.text = inventory.ToString();
        interactText.text = interact.ToString();
        #endregion
        //which key is being assigned
        switch (assignKey)
        {
            case "forward":
                forward = newKey; //the forward button is now the key that was pressed
                break;
            case "backward":
                backward = newKey;
                break;
            case "left":
                left = newKey;
                break;
            case "right":
                right = newKey;
                break;
            case "jump":
                jump = newKey;
                break;
            case "crouch":
                crouch = newKey;
                break;
            case "run":
                run = newKey;
                break;
            case "inventory":
                inventory = newKey;
                break;
            case "interact":
                interact = newKey;
                break;
        }
    }
    public void Resolution()//sets the resolution
    {
        resIndex = resDropdown.value;
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, Screen.fullScreen);
    }
    public void Windowed()//sets windowed mode
    {
        isFullScreen = windowedToggle.isOn;
        Screen.SetResolution(Screen.width, Screen.height, isFullScreen);
    }
    public void KeyBinds(string button)
    {
        waitingForKey = true;
        if (button == forwardButton)
        {
            assignKey = "forward";
            newKey = KeyCode.None;
        }
        else if (button == backwardButton)
        {
            assignKey = "backward";
            newKey = KeyCode.None;
        }
        else if (button == leftButton)
        {
            assignKey = "left";
            newKey = KeyCode.None;
        }
        else if (button == rightButton)
        {
            assignKey = "right";
            newKey = KeyCode.None;
        }
        else if (button == jumpButton)
        {
            assignKey = "jump";
            newKey = KeyCode.None;
        }
        else if (button == crouchButton)
        {
            assignKey = "crouch";
            newKey = KeyCode.None;
        }
        else if (button == runButton)
        {
            assignKey = "run";
            newKey = KeyCode.None;
        }
        else if (button == interactButton)
        {
            assignKey = "interact";
            newKey = KeyCode.None;
        }
        else if (button == inventoryButton)
        {
            assignKey = "inventory";
            newKey = KeyCode.None;
        }
    }

    public void SavePrefs()
    {
        optionsData.forward = forward;
        optionsData.backward = backward;
        optionsData.right = right;
        optionsData.left = left;
        optionsData.run = run;
        optionsData.crouch = crouch;
        optionsData.inventory = inventory;
        optionsData.interact = interact;
        optionsData.jump = jump;
        optionsData.volume = volume;
        optionsData.resolution = res[resIndex];
        optionsData.isFullScreen = isFullScreen;


        var serializer = new XmlSerializer(typeof(OptionPrefs));
        using (var stream = new FileStream(Application.persistentDataPath + "/" + fileName + ".xml", FileMode.Create))
        {
            serializer.Serialize(stream, optionsData);
        }
    }
}
