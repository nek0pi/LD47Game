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
    public bool isActiveElectricity;

    [SerializeField]
    private int hourStart; //Время откуда начинается отсчет
    private int hour; //Просто отвечает за время
    private float timer;
    private float inGameHour = 120f; //Понять на 120F. Для теста пока 10
    private bool isAM =true;

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
        clockText.text = hourStart + (isAM ? " A.M." : " P.M.");
    }

    public void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= inGameHour)    //Очень извиняюсь, но времени уже нет. 
        {
            timer = 0;
            hour++;
            if (hour > 12)
            {
                isAM = !isAM;
                hour = 0;
            }

            clockText.text = hour.ToString() + (isAM ? " A.M." : " P.M.");
        }
    }

    public void ResetTimer()
    {
        isAM = true;
        hour = hourStart;
        clockText.text = hourStart + (isAM ? " A.M." : " P.M.");
    }

    public void ResetWord()
    {
        resetIteration++;
        ResetTimer();
        onReset?.Invoke(resetIteration);
    }

}
