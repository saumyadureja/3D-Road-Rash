using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Transform playerTransform;
    public readonly int maxNoOfObstacles = 30;
    private float obstacleCreatedTillZ;
    private float safeZone;
    private float playerStartZ;
    private float obstacleGenerateWindow = 100.0f;
    private LinkedList<GameObject> activeObstacles;

    // Start is called before the first frame update
    void Start()
    {
        activeObstacles = GetComponent<RohitGlobals>().activeObstacles;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Initial offset for spawnZ as 45 from player start position
        safeZone = playerTransform.position.z + 50.0f;
        obstacleCreatedTillZ = safeZone ;
        spawnObstaclesOnZ(obstacleCreatedTillZ);
        obstacleCreatedTillZ += obstacleGenerateWindow;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > safeZone && playerTransform.position.z + obstacleGenerateWindow > obstacleCreatedTillZ)
        {
            spawnObstaclesOnZ(obstacleCreatedTillZ);
            obstacleCreatedTillZ += obstacleGenerateWindow;
        }
    }
    private void spawnObstaclesOnZ(float start) 
    {
        for (float  i = start; i < start + obstacleGenerateWindow; i += 10 )
        {
            Vector3 position = new Vector3(Random.Range(-6.0f, 6.0f), 1, i);
            GameObject go;
            go = Instantiate(obstaclePrefabs[Random.Range(0, 3)]);
            go.transform.SetParent(GameObject.FindGameObjectWithTag("ObstacleManagerTag").transform);
            go.transform.position = position;

            activeObstacles.AddLast(go);

            if(activeObstacles.Count > maxNoOfObstacles)
            {
                GameObject goRemoved = activeObstacles.First.Value;
                Destroy(goRemoved);
                activeObstacles.RemoveFirst();
            }
        }
        
    }

    
}
