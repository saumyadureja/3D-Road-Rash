using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RohitPathGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ= -5.0f ; // where on z axis do we want the object to be
    private float tileLength= 10.0f;
    private int amnTilesOnScreen= 5;
    private List<GameObject> activeTiles;
    private float safeZone = 15.0f;

    private int lastPrefabIndex=0;
    // Start is called before the first frame update
    private void Start()
    {
        activeTiles=new List<GameObject>();
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
        for(int i=0;i<amnTilesOnScreen;i++)
        {
            if(i<2)
                SpawnTile(0);
            SpawnTile();

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
        if (prefabIndex ==-1)
            go=Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go=Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position =Vector3.forward*spawnZ;
        spawnZ +=tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <=1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex ==lastPrefabIndex)
        {
            randomIndex = Random.Range (0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
