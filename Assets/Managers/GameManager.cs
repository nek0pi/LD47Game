using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int resetIteration = 0;

    public delegate void OnReset(int currentIteration);
    public event OnReset onReset;

    public event Action onTime;

    public bool isActiveElectricity;
    public bool isWaterPuddlePlaced = false;
    public GameObject spider;

    public GameOver gameOver;

    [SerializeField]
    private int hourStart; //Время откуда начинается отсчет
    private int hour; //Просто отвечает за время
    private float timer;
    private float inGameHour = 12f; //Понять на 120F. Для теста пока 10
    private bool isPM =true;

    [SerializeField]
    private TextMeshProUGUI clockText;

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
        InitializeClock();
    
    }

    private void InitializeClock()
    {
        clockText.text = hourStart + (isPM ? " P.M." : " A.M.");
        hour = hourStart;
    }

    public void Update()
    {
        if(isPM)
        timer += Time.deltaTime;

        if (hour == 2)
        {
            StartCoroutine(LightManager.instance.DayToNoon());
        }

        if (timer >= inGameHour)    //Очень извиняюсь, но времени уже нет. 
        {
            timer = 0;
            hour++;

            if (hour == 8)
            {
                StartCoroutine(LightManager.instance.DayToNight());
            }

            else if(hour > 12)
            {
                isPM = !isPM;
                hour = 0;
                onTime?.Invoke();
            }

            clockText.text = hour.ToString() + (isPM ? " P.M." : " A.M.");
        }
    }

    public void ResetTimer()
    {
        isPM = true;
        hour = hourStart;
        clockText.text = hourStart + (isPM ? " P.M." : " A.M.");
    }

    public void ResetWord()
    {
        StartCoroutine(gameOver.PlayGameOver());
        resetIteration++;
        ResetTimer();
        onReset?.Invoke(resetIteration);
    }

    public void ActivateSpider()
    {
        spider.SetActive(true);
    }
}
