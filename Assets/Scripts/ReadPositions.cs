using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadPositions : MonoBehaviour
{

    //public Transform prefab;
    private float tileLength = 10.0f;
    private float add = 0.0f;

    void Start()
    {
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        //StreamReader streamReader = new StreamReader("Assets/Resources/Files/Level1_Path.csv");
        TextAsset txt = (TextAsset)Resources.Load("Files/Level1_Path", typeof(TextAsset));
        string filecontent = txt.text;

        string[] positionArray = filecontent.Split('\n');

        for(int i = 0; i < positionArray.Length; i++)
        { 
            string data = positionArray[i].Trim();
            Debug.Log(i + ":" + data);
            if (data == "Tile_Main")
            {                    
                GameObject tileNewPrefab = Instantiate(Resources.Load("Tile_Main"), new Vector3(0, 0, add), Quaternion.identity) as GameObject;
                add += tileLength;
                tileNewPrefab.transform.SetParent(this.transform);
            }
            else if (data == "Tile_Ramp")
            {
                GameObject tileNewPrefab = Instantiate(Resources.Load("Tile_Ramp"), new Vector3(0, 0, add), Quaternion.Euler(-35, 0, 0)) as GameObject;
                add += 2*tileLength;
                tileNewPrefab.transform.SetParent(this.transform);
            }
            else if(data == "Wall")
            {
                GameObject wall = Instantiate(Resources.Load("wall_sphere"), new Vector3(-0.46f, 4, add), Quaternion.Euler(-90, 0, 0)) as GameObject;
                wall.transform.SetParent(this.transform);
            }
            else
            {
                continue;
            }
        }

    }


}