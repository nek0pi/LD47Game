using UnityEngine;
public class DeathManager : MonoBehaviour
{
    public static DeathManager Instance;
    public AudioClip DeathClip;
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
        GetComponent<AudioSource>().clip = DeathClip;
        GetComponent<AudioSource>().Play();
        GameManager.instance.ResetWord(); 
    }
}