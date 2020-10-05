using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public static ResolutionManager instance;
    private Vector2Int currentResolution;
    private bool fullScreen;
    [SerializeField]
    private TMPro.TMP_Dropdown dropdownResolution;
    [SerializeField]
    private Toggle isFullScreen;


    private Vector2Int[] resolutions = { new Vector2Int (640, 480), new Vector2Int(800, 600), new Vector2Int(1280, 720), new Vector2Int(1920, 1080)};

    public void Awake()
    {
        //Сделать проверку на null
        fullScreen = PlayerPrefs.GetInt("_FullScreen") == 1 ? true : false;
        currentResolution = new Vector2Int(PlayerPrefs.GetInt("_ResolutionW"), PlayerPrefs.GetInt("_ResolutionH"));
        Screen.SetResolution(currentResolution.x, currentResolution.y, fullScreen);
        isFullScreen.isOn = fullScreen;
        dropdownResolution.value = Array.IndexOf(resolutions, currentResolution);
    }

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
        DontDestroyOnLoad(gameObject);
        InitializeResolutionManager();
    }

    private void InitializeResolutionManager()
    {
        currentResolution = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
        fullScreen = Screen.fullScreen;
    }

    public void ChangeResolution(Int32 resolution)
    {
        //Sorry not sorry :)
        currentResolution = resolutions[resolution];

        Screen.SetResolution(currentResolution.x, currentResolution.y, fullScreen);
        PlayerPrefs.SetInt("_ResolutionW", currentResolution.x);
        PlayerPrefs.SetInt("_ResolutionH", currentResolution.y);

    }

    public void SetFullScreen(bool state)
    {
        fullScreen = state;
        PlayerPrefs.SetInt("_FullScreen", fullScreen ? 1 : 0);
        Screen.SetResolution(currentResolution.x, currentResolution.y, fullScreen);
    }

}

