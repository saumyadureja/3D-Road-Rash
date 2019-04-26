using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlaceObstacles : MonoBehaviour
{
    public LinkedList<GameObject> walls;
    public string fileName;
    private System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        walls = new LinkedList<GameObject>();
        rnd = new System.Random();
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        StreamReader streamReader = new StreamReader("Assets/Resources/Files/" + fileName);
        bool eof = false;
       
        while (!eof)
        {
            string data = streamReader.ReadLine ();
            if(data == null)
            {
                eof = true;
                break;
            }

            string[] data_values = data.Split(',');
            
            // Debug.Log(Line + ": "+data_values[i]);

            string type = data_values[0];

            if (type == "") {
                Debug.LogWarning("Empty line in CSV?");
                continue;
            }

            Quaternion rotation;
            Vector3 position;
            switch (type)
            {
            case "Obstacle_Sphere":
            case "Obstacle_Cube":
            case "Obstacle_Cylinder":
                rotation = Quaternion.Euler(0,0,0);
                position = new Vector3(
                    int.Parse(data_values[1]),
                    int.Parse(data_values[2]) + 0.5f,
                    int.Parse(data_values[3]));

                if (type == "Obstacle_Sphere")
                {
                    rotation = Quaternion.Euler(0,90,0);
                }

                if (type == "Obstacle_Cylinder")
                {
                    position = new Vector3(position.x, position.y + 1f, position.z);
                }

                GameObject obstacle = Instantiate(Resources.Load(type), position, rotation) as GameObject;
                obstacle.transform.SetParent(this.transform);

                int number = rnd.Next(10);
                // Debug.Log(type + " was assigned " + number);
                Renderer rend = obstacle.GetComponent<Renderer>();
                Texture numText = Resources.Load("Numbers/" + number) as Texture;
                rend.material.mainTexture = numText;

                break;

            case "wall_cube":
            case "wall_sphere":
            case "wall_both":
                rotation = Quaternion.Euler(-90,0,0);
                position = new Vector3(
                    int.Parse(data_values[1]),
                    int.Parse(data_values[2]),
                    int.Parse(data_values[3]));
                GameObject wall = Instantiate(Resources.Load(type), position, rotation) as GameObject;
                wall.transform.SetParent(this.transform);
                walls.AddLast(wall);

                break;

            default: Debug.LogWarning("Unrecognized obstacle type '" + type + "' in CSV.");

                break;
            }            
        }
        Debug.Log("Walls size: " + walls.Count);
        RemoveWall(5.0f);
    }

    public void RemoveWall(float zPosition)
    {
        //Debug.Log("Wall count: " + walls.Count);
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
