using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class HexMesh : MonoBehaviour
{

    Mesh hexMesh;
    List<Vector3> vertices;
    List<int> triangles;

    void Awake()
    {
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
        GetComponent<MeshCollider>().sharedMesh = hexMesh;
        hexMesh.name = "Hex Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }


    void Start()
    {
       Triangulate();

    }


    public void Triangulate()
    {
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();

        Triangulatee();

        hexMesh.vertices = vertices.ToArray();
        hexMesh.triangles = triangles.ToArray();
        hexMesh.RecalculateNormals();
    }

    void Triangulatee()
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 center = transform.localPosition;
            AddTriangle(
                center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i+1]
            );
        }
    }

    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }

}
