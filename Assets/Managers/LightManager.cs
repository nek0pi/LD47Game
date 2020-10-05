using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public static LightManager instance;

    [SerializeField]
    Light2D mainLight;

    public void Start()
    {
        DOTween.Init();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator DayToNight()
    {
        float timeElapsed = 0f;
        float totalTime = 48f;

        while (timeElapsed < totalTime)
        {
            timeElapsed += Time.deltaTime;
            mainLight.color = Color.LerpUnclamped(new Color(0.86f, 0.107f, 0.180f), new Color(0.3254272f, 0.3957597f, 0.6698113f), timeElapsed / totalTime);
            yield return null;
        }

    }

    public IEnumerator DayToNoon()
    {
        float timeElapsed = 0f;
        float totalTime = 60f;

        while (timeElapsed < totalTime)
        {
            timeElapsed += Time.deltaTime;
            mainLight.color = Color.LerpUnclamped(Color.white, new Color(0.86f, 0.107f, 0.180f), timeElapsed / totalTime);
            yield return null;
        }
    }
}
