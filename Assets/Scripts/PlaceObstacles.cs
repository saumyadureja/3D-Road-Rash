using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlaceObstacles : MonoBehaviour
{
    // public LinkedList<GameObject> walls;
    public string fileName;
    private System.Random rnd;
    LinkedList<int> targetList; 

    // Start is called before the first frame update
    void Start()
    {
        // walls = new LinkedList<GameObject>();
        targetList = new LinkedList<int>();
        rnd = new System.Random();
        ReadCSVFile();
       
        Debug.Log("Got the size in place obstacles: " + targetList.Count);
        GameObject.Find("Player").GetComponent<RohitScoresCalculations>().setTargetList(targetList);
    }

    void ReadCSVFile()
    {
        // StreamReader streamReader = new StreamReader("Assets/Resources/Files/" + fileName);
        TextAsset txt = (TextAsset)Resources.Load("Files/Level1_Obstacles", typeof(TextAsset));
        string filecontent = txt.text;

        string[] positionArray = filecontent.Split('\n');

        for (int i = 0; i < positionArray.Length; i++)
        {
            string data = positionArray[i].Trim();
            // Debug.Log(i + ":" + data);
           
            if(data == null || data.Length == 0)
            {
                
                continue;
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
            int numberValue;
            switch (type)
            {
            case "Obstacle_Sphere":
            case "Obstacle_Cube":
            case "Obstacle_Cylinder":
                rotation = Quaternion.Euler(0,0,0);
                numberValue = int.Parse(data_values[4]);
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

                // int number = rnd.Next(10);
                // Debug.Log(type + " was assigned " + number);
                Renderer rend = obstacle.GetComponent<Renderer>();
                Texture numText = Resources.Load("Numbers/" + numberValue) as Texture;
                rend.material.mainTexture = numText;

                break;

            case "wall_cube":
            case "wall_sphere":
            case "wall_both":
                rotation = Quaternion.Euler(-90,0,0);
                numberValue = int.Parse(data_values[4]);
                position = new Vector3(
                    int.Parse(data_values[1]),
                    int.Parse(data_values[2]),
                    int.Parse(data_values[3]));
                GameObject wall = Instantiate(Resources.Load(type), position, rotation) as GameObject;
                wall.transform.SetParent(this.transform);
                // walls.AddLast(wall);

                Renderer wallRend = wall.GetComponent<Renderer>();
                Texture wallNumText = Resources.Load("Numbers/" + numberValue) as Texture;
                wallRend.material.mainTexture = wallNumText;

                targetList.AddLast(numberValue);
                break;

            default: Debug.LogWarning("Unrecognized obstacle type '" + type + "' in CSV.");

                break;
            }            
        }
        // Debug.Log("Walls size: " + walls.Count);
        // RemoveWall(5.0f);
    }

    //public void RemoveWall(float zPosition)
    //{
    //    //Debug.Log("Wall count: " + walls.Count);
    //    if (walls.Count > 0)
    //    {
    //        GameObject firstWall = walls.First.Value;
    //        if (firstWall.transform.position.z < zPosition)
    //        {
    //            walls.RemoveFirst();
    //            Destroy(firstWall);
    //        }
    //    }
    //}
}
