using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlaceObstacles : MonoBehaviour
{
    public LinkedList<GameObject> walls;
    // Start is called before the first frame update
    void Start()
    {
        walls = new LinkedList<GameObject>();
        ReadCSVFile();  
    }

    // Update is called once per frame
    void ReadCSVFile()
    {
         StreamReader streamReader = new StreamReader("Assets/Resources/Files/Level1_Obstacles.csv");
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
                    Cube.transform.SetParent(transform);
                }
                //GameObject tileInstances1 = Instantiate(Resources.Load("TileNew"), new Vector3(0, 0, 30), Quaternion.identity) as GameObject;
                if (data_values[i] == "Obstacle_Sphere")
                {
                    GameObject Sphere = Instantiate(Resources.Load("Obstacle_Sphere"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.identity) as GameObject;
                    Sphere.transform.SetParent(transform);
                }
                if (data_values[i] == "Obstacle_Cylinder")
                {
                    GameObject Cylinder = Instantiate(Resources.Load("Obstacle_Cylinder"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.Euler(-90, 0, 90)) as GameObject;
                    Cylinder.transform.SetParent(transform);
                }
                if (data_values[i] == "wall_cube")
                {
                    GameObject Wall = Instantiate(Resources.Load("wall_cube"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.Euler(-90, 0, 0)) as GameObject;
                    Wall.transform.SetParent(transform);
                    walls.AddLast(Wall);
                }
                if (data_values[i] == "wall_sphere")
                {
                    GameObject Wall = Instantiate(Resources.Load("wall_sphere"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.Euler(-90, 0, 0)) as GameObject;
                    Wall.transform.SetParent(transform);
                    walls.AddLast(Wall);
                }
                if (data_values[i] == "wall_both")
                {
                    GameObject Wall = Instantiate(Resources.Load("wall_both"), new Vector3(int.Parse(data_values[i + 1]), int.Parse(data_values[i + 2]), int.Parse(data_values[i + 3])), Quaternion.Euler(-90, 0, 0)) as GameObject;
                    Wall.transform.SetParent(transform);
                    walls.AddLast(Wall);
                }
            }

            
        }
        Debug.Log("Walls size: " + walls.Count);
        RemoveWall(5.0f);
    }

    public void RemoveWall(float zPosition)
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
