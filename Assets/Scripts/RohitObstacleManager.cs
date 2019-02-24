using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Transform playerTransform;
    // private readonly int noOfObstacles = 10;
    private float obstacleCreatedTillZ;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        obstacleCreatedTillZ = playerTransform.position.z + 25.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z + 50.0f > obstacleCreatedTillZ)
        {
            spawnObstaclesOnZ(obstacleCreatedTillZ);
            obstacleCreatedTillZ += 50;
        }
    }
    private void spawnObstaclesOnZ(float start) 
    {
        for (float  i = start; i < start + 50.0f; i += 10 )
        {
            Vector3 position = new Vector3(Random.Range(-6.0f, 6.0f), 2, i);
            GameObject go;
            go = Instantiate(obstaclePrefabs[Random.Range(0, 3)]);
            go.transform.SetParent(GameObject.FindGameObjectWithTag("ObstacleManagerTag").transform);
            go.transform.position = position;
        }
        
    }
}
