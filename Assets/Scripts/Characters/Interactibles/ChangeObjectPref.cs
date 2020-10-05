using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimeConsumingTask))]
public class ChangeObjectPref : MonoBehaviour
{
    public GameObject ChangingPrefab;

    private void Start()
    {
        GetComponent<TimeConsumingTask>().OnInteract += ChangePrefab;

    }
    public void ChangePrefab()
    {
        Instantiate(ChangingPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
