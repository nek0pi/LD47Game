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
            //mainLight.intensity = Mathf.Lerp(mainLight.intensity, 0.85f, timeElapsed / totalTime);

            //var color = Color.Lerp(mainLight.color, new Color(86, 107, 180), timeElapsed / totalTime);
            mainLight.color = Color.LerpUnclamped(new Color(0.86f, 0.107f, 0.180f), new Color(0.3254272f, 0.3957597f, 0.6698113f), timeElapsed / totalTime);
            yield return null;
        }
        //DOTween.To(() => mainLight.color, x => mainLight.color = x, new Color(86, 107, 180), 48f);
        //DOTween.To(() => mainLight.intensity, x => mainLight.intensity = x, 0.83f, 48f);

    }

    public IEnumerator DayToNoon()
    {
        float timeElapsed = 0f;
        float totalTime = 60f;

        while (timeElapsed < totalTime)
        {
            timeElapsed += Time.deltaTime;
            //mainLight.intensity = Mathf.Lerp(mainLight.intensity, 0.85f, timeElapsed / totalTime);

            //var color = Color.Lerp(mainLight.color, new Color(86, 107, 180), timeElapsed / totalTime);
            mainLight.color = Color.LerpUnclamped(Color.white, new Color(0.86f, 0.107f, 0.180f), timeElapsed / totalTime);
            yield return null;
        }
        //DOTween.To(() => mainLight.color, x => mainLight.color = x, new Color(241, 172, 167), 48f);
        //yield return new WaitForSeconds(12f);
    }
}
