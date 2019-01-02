using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadMeshStream : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string triPath = "M:/streamGH/triangle01.txt";
        string vertPath = "M:/streamGH/vert01.txt";

        StreamReader vertReader = new StreamReader(vertPath);




        foreach (string word in triData)
        {
            Debug.Log(word);

        }
    }

    Vector3[] convertTriangleToV3Array(string triPath)
    {
        StreamReader triReader = new StreamReader(triPath);
        string[] triData = triReader.ReadToEnd().Replace("T{", "").Replace("}", "").Replace("\r\n", "-").Split('-');

        foreach (string item in triData)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
