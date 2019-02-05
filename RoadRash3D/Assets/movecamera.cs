using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour

{
    private Vector3 offset;
    public GameObject Sphere; 
    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<Rigidbody>().velocity= new Vector3 (0,0,4);
         offset = transform.position - Sphere.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Sphere.transform.position + offset;
    }
}
