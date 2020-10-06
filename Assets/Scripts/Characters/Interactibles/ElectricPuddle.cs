using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPuddle : MonoBehaviour
{
    public float stunTime = 15f;

    private void Start()
    {
        GameManager.instance.onReset += OnReset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //  kill player
            var ic = collision.gameObject.GetComponent<InputContoller>();
            ic.SetState(new PlayerNoControlState(ic));
            DeathManager.Instance.Die();
            
        }
        else if (collision.CompareTag("Enemy"))
        {
            // Stun an enemy
            StartCoroutine(Waituntilgetbackup(collision));
            // Hide a puddle and make it non collidable
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            // Blow up an electrical generator
            BlowUpGeneratorSpawner.instance.SpawnGenerator();
            collision.gameObject.tag = "Interactable";

            collision.GetComponent<Animator>().SetBool("isStunned", true);
        }
    }

    private IEnumerator Waituntilgetbackup(Collider2D collision)
    {
        var ec = collision.GetComponent<EnemyController>();
        ec.GetComponent<Pathfinding.AIPath>().maxSpeed = 0;
        ec.SetState(new EnemyStunnedState(ec));

        yield return new WaitForSeconds(stunTime);
        ec.GetComponent<Pathfinding.AIPath>().maxSpeed = 4;
        ec.SetState(new EnemyNormalState(ec));

        collision.GetComponent<Animator>().SetBool("isStunned", false);
        Destroy(gameObject);
    }

    public void OnReset(int n) { GameManager.instance.onReset -= OnReset; Destroy(gameObject); }
}
