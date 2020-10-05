using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorRemover : MonoBehaviour
{

    private void Start()
    {
        BlowUpGeneratorSpawner.instance.RemoveGen += BlowUp;
    }

    private void BlowUp()
    {
        Destroy(gameObject);
    }
}
