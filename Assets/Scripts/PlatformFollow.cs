using UnityEngine;

public class PlatformFollow : MonoBehaviour
{
    public GameObject platform;
    private Vector3 offset;
    public float lerpRate = 2;

    private void Start()
    {
        offset = platform.transform.position - transform.position;
    }
    private void Update()
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
