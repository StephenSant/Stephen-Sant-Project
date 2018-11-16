using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [HideInInspector]
    public bool showOptions;
    [Header("References")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

	void Start ()
    {
        mainMenu = GameObject.Find("MainMenuPanel");
        optionsMenu = GameObject.Find("OptionsPanel");
        showOptions = false;
    }

    public void NewGame()
    {

    }

    public void GoToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
