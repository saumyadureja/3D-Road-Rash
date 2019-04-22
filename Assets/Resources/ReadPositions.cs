using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadPositions : MonoBehaviour
{

    //public Transform prefab;
    private float tileLength = 10.0f;
    private float add = 10.0f;

    void Start()
    {
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        StreamReader streamReader = new StreamReader("Assets/Resources/positions.csv");
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
                if (data_values[i] == "TileNewL1")
                {
                    add += tileLength;
                    GameObject tileNewPrefab = Instantiate(Resources.Load("TileNewL1"), new Vector3(0, 0, add), Quaternion.identity) as GameObject;


                }
                //GameObject tileInstances1 = Instantiate(Resources.Load("TileNew"), new Vector3(0, 0, 30), Quaternion.identity) as GameObject;
                if (data_values[i] == "Tile_RampLeftL1")
                {
                    add += tileLength;
                    GameObject tileLeftPrefab = Instantiate(Resources.Load("Tile_RampLeftL1"), new Vector3(0, 0, add), Quaternion.Euler(-25, 0, 0)) as GameObject;


                }
                if (data_values[i] == "Tile_RampRightL1")
                {
                    add += tileLength;
                    GameObject tileRightPrefab = Instantiate(Resources.Load("Tile_RampRightL1"), new Vector3(0, 0, add), Quaternion.Euler(-25, 0, 0)) as GameObject;

                }

            }

        }

    }


}