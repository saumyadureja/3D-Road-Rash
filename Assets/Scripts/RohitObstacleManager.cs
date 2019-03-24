using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Transform playerTransform;
    private readonly int maxNoOfObstacles = 30;
    private float obstacleCreatedTillZ;
    private float safeZone;
    private float playerStartZ;
    private float obstacleGenerateWindow = 100.0f;
    //public LinkedList<GameObject> obsList;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Globals>().activeObjects = new LinkedList<GameObject>();
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
        for (float  i = start; i < start + obstacleGenerateWindow; i += 15 )
        {
            Vector3 position = new Vector3(Random.Range(-6.0f, 6.0f), 1, i);
            GameObject go;
            Debug.Log("Calling getPrefabIndex:" + i);
            int prefabIndex = GetRandomIndex();
            go = Instantiate(obstaclePrefabs[prefabIndex]);
            go.transform.SetParent(GameObject.FindGameObjectWithTag("ObstacleManagerTag").transform);
            go.transform.position = position;

            LinkedList<GameObject> list = GetComponent<Globals>().activeObjects;
            list.AddLast(go);

            if (list.Count > maxNoOfObstacles)
            {
                GameObject goRemoved = list.First.Value;
                Destroy(goRemoved);
                list.RemoveFirst();
            }
        }
        
    }

    private int GetRandomIndex()
    {       
        int rand = Random.Range(0, 100);
        int prefabIndex;
        if (rand > 80)
        {
            prefabIndex = 3;
        }
        else
        {
            prefabIndex = Random.Range(0, 3);
        }
        Debug.Log("Inside random prefab creation Probability: " + rand + "Returned value: "  + prefabIndex);

        return prefabIndex;

    }

    
}
