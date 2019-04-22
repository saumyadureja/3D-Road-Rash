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
        StreamReader streamReader = new StreamReader("Assets/Resources/Files/positions.csv");
        bool eof = false;

        while (!eof)
        {
            string data = streamReader.ReadLine();
            if (data == null)
            {
                eof = true;
                break;


            }
            string[] data_values = data.Split(',');
            for (int i = 0; i < data_values.Length; i++)
            {
                //Debug.Log("Values:" + i.ToString() + " " + data_values[i].ToString());
                //Debug.Log(data_values[i].ToString());

                //Debug.Log(" value: "+data_values[i]);//4
                if (data_values[i] == "Tile_Main")
                {
                    
                    GameObject tileNewPrefab = Instantiate(Resources.Load("Tile_Main"), new Vector3(0, 0, add), Quaternion.identity) as GameObject;
                    add += tileLength;

                }
                //GameObject tileInstances1 = Instantiate(Resources.Load("Tile_Ramp"), new Vector3(0, 0, 30), Quaternion.identity) as GameObject;
                if (data_values[i] == "Tile_Ramp")
                {
                    
                    GameObject tileLeftPrefab = Instantiate(Resources.Load("Tile_Ramp"), new Vector3(0, 0, add), Quaternion.Euler(-25, 0, 0)) as GameObject;
                    add += tileLength;

                }

            }

        }

    }


}