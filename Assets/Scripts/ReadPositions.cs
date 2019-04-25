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
        StreamReader streamReader = new StreamReader("Assets/Resources/Files/Level1_Path.csv");
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
                if (data_values[i] == "Tile_Main")
                {
                    
                    GameObject tileNewPrefab = Instantiate(Resources.Load("Tile_Main"), new Vector3(0, 0, add), Quaternion.identity) as GameObject;
                    add += tileLength;
                    tileNewPrefab.transform.SetParent(transform);

                }
                if (data_values[i] == "Tile_Ramp")
                {

                    GameObject tileNewPrefab = Instantiate(Resources.Load("Tile_Ramp"), new Vector3(0, 0, add), Quaternion.Euler(-35, 0, 0)) as GameObject;
                    add += 2*tileLength;
                    tileNewPrefab.transform.SetParent(transform);
                }
                
            }

        }

    }


}