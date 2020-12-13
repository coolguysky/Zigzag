using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public bool falldown;

    private void Start()
    {
        falldown = false;
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Invoke(nameof(FallDown), 1f);
            falldown = true;
        }
    }
    private void FallDown()
    {
        GetComponentInParent<Rigidbody>().isKinematic = false;
        GetComponentInParent<Rigidbody>().useGravity = true;
        Destroy(transform.parent.gameObject, 2f);
    }
}
