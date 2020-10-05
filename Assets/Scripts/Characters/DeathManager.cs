using UnityEngine;
public class DeathManager : MonoBehaviour
{
    public static DeathManager Instance;
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
    public void Die() { GameManager.instance.ResetWord(); }
}