using UnityEngine;
using DG.Tweening;
public class DeathManager : MonoBehaviour
{
    public static DeathManager Instance;
    public AudioClip AudioClip;
    public void Start()
    {
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
    public void Die() 
    {
        GetComponent<AudioSource>().clip = AudioClip;
        GetComponent<AudioSource>().Play();
        GameManager.instance.ResetWord(); 
    }
}