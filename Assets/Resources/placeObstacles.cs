using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class placeObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      ReadCSVFile();  
    }

    // Update is called once per frame
    void ReadCSVFile()
    {
         StreamReader streamReader = new StreamReader("Assets/Resources/obstaclePositions.csv");
        bool eof = false;
       
        while (!eof)
        {
            string data = streamReader.ReadLine ();
            if(data ==null)
            {
                eof = true;
                break;


            }
            string[] data_values = data.Split(',');
            for(int i = 0; i < data_values.Length; i++)
            {
                //Debug.Log("Values:" + i.ToString() + " " + data_values[i].ToString());
                //Debug.Log(data_values[i].ToString());
                
                //Debug.Log(" value: "+data_values[i]);//4
                if (data_values[i] == "Obstacle_Cube")
                {
                    GameObject Cube = Instantiate(Resources.Load("Obstacle_Cube"), new Vector3(int.Parse(data_values[i+1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.Euler(-90,0,0)) as GameObject;

                }
                //GameObject tileInstances1 = Instantiate(Resources.Load("TileNew"), new Vector3(0, 0, 30), Quaternion.identity) as GameObject;
                if (data_values[i] == "Obstacle_Sphere")
                {
                    GameObject Sphere = Instantiate(Resources.Load("Obstacle_Sphere"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.identity) as GameObject;

                }
                if (data_values[i] == "Obstacle_Cylinder")
                {
                    GameObject Cylinder = Instantiate(Resources.Load("Obstacle_Cylinder"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.Euler(-90, 0, 90)) as GameObject;

                }
                if (data_values[i] == "wall")
                {
                    GameObject Wall = Instantiate(Resources.Load("wall"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.Euler(-90, 0, 0)) as GameObject;

                }
            }

        } 
    }
}
