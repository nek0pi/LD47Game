using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingObject : MonoBehaviour
{
    public float animationTime = 0.2f;
    public void KillHero()
    {
        StartCoroutine(KillAndAnimation());
    }

    IEnumerator KillAndAnimation()
    {
        yield return new WaitForSeconds(animationTime);
        DeathManager.Instance.Die();
    }
}
