using DG.Tweening;
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
        DOTween.To(() => mainLight.color, x => mainLight.color = x, new Color(241, 172, 167), 5f);
        yield return new WaitForSeconds(1f);
        
        DOTween.To(() => mainLight.color, x => mainLight.color = x, new Color(86, 107, 180), 5f);
        DOTween.To(() => mainLight.intensity, x => mainLight.intensity = x, 0.83f, 5f);
        Debug.Log("asd");
    }

}
