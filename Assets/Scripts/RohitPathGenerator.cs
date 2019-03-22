using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitPathGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ= -5.0f ; // where on z axis do we want the object to be
    private float tileLength = 10.0f;
    private float rampLength = 37.0f;
    private int amnTilesOnScreen= 10;
    private List<GameObject> activeTiles;
    private float safeZone = 15.0f;

    // private int lastPrefabIndex=0;
    // Start is called before the first frame update
    private void Start()
    {
        activeTiles=new List<GameObject>();
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
        for(int i=0;i<amnTilesOnScreen;i++)
        {
            if(i<3)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }                
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z- safeZone > (spawnZ - amnTilesOnScreen*tileLength))
            {
                SpawnTile();
                DeleteTile();
            }
    }
    private void SpawnTile(int prefabIndex =-1)
    {
        GameObject go;
        float add=0.0f;
        if (prefabIndex ==-1)
        {
            int index = RandomPrefabIndex();
            if(index == 1)
            {
                add = rampLength;
                // Ramp is spawned so destroy all obstacles
                Debug.Log("Ramp Created calling destroy obstacles");
                DestroyObstacles(spawnZ,add);                
            } else
            {
                add = tileLength;
            }
            go = Instantiate(tilePrefabs[index]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position =Vector3.forward*spawnZ;
            spawnZ+=add;
            activeTiles.Add(go);
        }            
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position =Vector3.forward*spawnZ;
            spawnZ+=tileLength;
            activeTiles.Add(go);
        }

            
      
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        System.Random getRandom = new System.Random();
        int rand = getRandom.Next(0, 100);
        if (rand > 90)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void DestroyObstacles(float spawnZ, float length)
    {
        GameObject go = GameObject.FindGameObjectWithTag("ObstacleManagerTag");

        Debug.Log("Child count:" + go.transform.childCount);

        for(int i = 0; i < go.transform.childCount; i++)
        {
            GameObject child = go.transform.GetChild(i).gameObject;
            Debug.Log("Child: " + i + "Name: " + child.name);
            Debug.Log("Child Position: " + child.transform.position.z + "SpawnZ: "  + spawnZ + "Length: " + length);
            if (spawnZ < child.transform.position.z && child.transform.position.z < spawnZ+length)
            {
                // Remove child from the linked list of active obstacles
                LinkedList<GameObject> list = GetComponent<RohitGlobals>().activeObstacles;
                int numOfMaxObstacles = GetComponent<RohitGlobals>().maxNoOfObstacles;

                if(list.Count > numOfMaxObstacles)
                {
                    list.Remove(child);
                }
                // Destroy  the child
                Debug.Log("Destroying:" + go.name);
                Destroy(child);
            }
        }

    }
}
