using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public LinkedList<GameObject> activeObjects;
    public int numOfObjects = 30;


    public LinkedList<GameObject> walls;

    void Start()
    {
        walls = new LinkedList<GameObject>();
    }

    public void removeWall(float zPosition)
    {
        Debug.Log("Wall count: " + walls.Count);
        if (walls.Count > 0)
        {
            GameObject firstWall = walls.First.Value;
            if (firstWall.transform.position.z < zPosition)
            {
                walls.RemoveFirst();
                Destroy(firstWall);
            }
        }
    }
}
