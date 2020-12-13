using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollow : MonoBehaviour
{
    public GameObject platform;
    Vector3 offset;
    float lerpRate = 2;

    void Start()
    {
        Vector3 cam = transform.position;
        Vector3 player = platform.transform.position;

        offset = platform.transform.position - transform.position;
    }
    void Update()
    {
        if (platform != null)
        {
            Vector3 pos = transform.position;
            Vector3 targetPos = platform.transform.position - offset;
            pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
            transform.position = pos;

            if (platform.GetComponentInChildren<TriggerChecker>().falldown)
            {
                Destroy(gameObject, 4f);
            }
        }
        
        
    }
}
