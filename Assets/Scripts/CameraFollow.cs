using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offset;
    public float lerpRate;
    public bool gameOver;

    private void Start()
    {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }
    private void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }
    private void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
