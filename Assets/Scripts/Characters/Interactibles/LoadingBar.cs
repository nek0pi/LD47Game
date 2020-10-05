using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider UISlider;
    public float minVal = 0, maxVal = 100;
    private float yOffset = 20f;
    private float increaseRate = 0.1f;
    public static LoadingBar Instance;
    private void Start()
    {
        //Make sure it's only one (singleton)
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        UISlider.minValue = minVal; UISlider.maxValue = maxVal;
        DOTween.Init();
    }

    public void Reset()
    {
        StopCoroutine("Interpolation");
        UISlider.value = 0;
    }
    public void StartLoading(float timeConsumes)
    {
        DOTween.To(() => UISlider.value, x => UISlider.value = x, maxVal, timeConsumes);

    }



}