
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public GameObject Target;
    bool isDead = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { Target = collision.gameObject; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { Target = null; isDead = false; }
    }

    public void Attack()
    {
        if (Target != null && isDead == false)
        {
            Debug.Log("Player has died");
            var ic = Target.GetComponent<InputContoller>();
            // add dying animation
            ic.GetComponent<MovementController>().CharAnimator.SetBool("isDead", true);
            ic.SetState(new PlayerNoControlState(ic));
            isDead = true;
            DeathManager.Instance.Die();
        }
    }
}
