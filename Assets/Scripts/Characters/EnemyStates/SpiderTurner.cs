using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTurner : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    private AIPath aiPath;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        aiPath = GetComponent<AIPath>();
    }
    private void Update()
    {
        Debug.Log(aiPath.speed);
        //if (aiPath.speed < 0) SpriteRenderer.flipX = true;
    }
}
