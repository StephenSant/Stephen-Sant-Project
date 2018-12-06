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
        mainMenu = GameObject.Find("Main Menu Panel");
        optionsMenu = GameObject.Find("Options Panel");
        optionsMenu.SetActive(false);
        showOptions = false;
    }

    void Update()
    {
        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void NewGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void GoToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ToggleOptions()
    {
        if (!showOptions)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            showOptions = true;
        }
        else if (showOptions)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            showOptions = false;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
