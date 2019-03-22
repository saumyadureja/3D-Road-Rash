using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RohitGlobals : MonoBehaviour
{
    public LinkedList<GameObject> activeObstacles;
    public readonly int maxNoOfObstacles = 30;
    // Start is called before the first frame update
    void Start()
    {
        activeObstacles = new LinkedList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
