using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    Vector3 lastPos;
    float size;
    public bool gameOver;
    public GameObject diamonds;
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i <20; i++)
        {
            SpawnPlatforms();
        }

        
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }

    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 2); // int is exclusive
        if(rand < 1)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }


    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        var plat = Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            var diamond = Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
            diamond.GetComponent<PlatformFollow>().platform = plat;
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        var plat = Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            var diamond = Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
            diamond.GetComponent<PlatformFollow>().platform = plat;
        }
    }


}
