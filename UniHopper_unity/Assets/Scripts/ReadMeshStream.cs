using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadMeshStream : MonoBehaviour
{
    // Start is called before the first frame update

    string triPath = "M:/streamGH/triangle01.txt";
    string vertPath = "M:/streamGH/vert01.txt";

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<MeshFilter>().mesh = ConstructMesh(ConvertTriangleToInt(triPath), ConvertVertexToV3Array(vertPath));
    }

    int[] ConvertTriangleToInt(string triPath)
    {
        StreamReader triReader = new StreamReader(triPath);
        string[] triData = triReader.ReadToEnd().Replace("T{", "").Replace("}", "").Replace("\r\n", ";").Split(';');
        triReader.Close();
        int[] triInt = new int[triData.Length];
        for (int i = 0; i < triData.Length; i++)
        {
            triInt[i] = int.Parse(triData[i].Split(';')[0]);
        }
        return triInt;
    }

    Vector3[] ConvertVertexToV3Array(string vertPath)
    {
        StreamReader vertReader = new StreamReader(vertPath);
        string[] vertData = vertReader.ReadToEnd().Replace("{", "").Replace("}", "").Replace("\r\n", ";").Split(';');
        vertReader.Close();
        Debug.Log(vertData.Length);
        Debug.Log(vertData[5]);
        Vector3[] vertVec3 = new Vector3[vertData.Length];

        for (int i = 0; i < vertData.Length; i++)
        {
            vertVec3[i] = new Vector3(float.Parse(vertData[i].Split(',')[0]),
                float.Parse(vertData[i].Split(',')[1]),
                float.Parse(vertData[i].Split(',')[2]));
        }
        return vertVec3;
    }

    Mesh ConstructMesh(int[] triangles, Vector3[] vertices)
    {
        Mesh genMesh = new Mesh();
        genMesh.vertices = vertices;
        genMesh.triangles = triangles;
        return genMesh;
    }

}
