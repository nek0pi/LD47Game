using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKillable : MonoBehaviour
{
    public AudioClip DieAudio;
    private void Start()
    {
        GetComponent<TimeConsumingTask>().OnInteract += WeJustWon;
    }

    public void WeJustWon()
    {
        GetComponent<Animator>().SetBool("isDead", true);
        GetComponent<AIPath>().canMove = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<AudioSource>().clip = DieAudio;
        GetComponent<AudioSource>().Play();
        GameManager.instance.FinishGame();
        
    }
}
