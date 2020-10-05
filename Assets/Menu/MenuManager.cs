using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public MenuState menuState = MenuState.MainMenu;

    [SerializeField]
    private GameObject[] mainMenuViews;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        //Он дальше нам не нужен, то пусть умирает.
    }
    public void SwapMenuView()
    {
        foreach (GameObject view in mainMenuViews)
            view.SetActive(false);
        
        mainMenuViews[(int)menuState].SetActive(true);
    }
    public void LoadMainLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/VladScene.unity", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeState(int state)
    {
        menuState = (MenuState)state;
    }
}

public enum MenuState : int
{ 
    MainMenu = 0, SettingsMenu, AboutMenu, ControlsMenu
}
