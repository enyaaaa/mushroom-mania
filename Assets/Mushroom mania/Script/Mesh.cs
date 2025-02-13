using UnityEngine;

public class GenerateMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        // Create vertices
        Vector3[] vertices = {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0)
        };
        mesh.vertices = vertices;

        // Create triangles (clockwise winding order)
        int[] triangles = { 0, 1, 2 };
        mesh.triangles = triangles;

        // Create normals (optional, but recommended)
        Vector3[] normals = {
            Vector3.forward,
            Vector3.forward,
            Vector3.forward
        };
        mesh.normals = normals;

        // Assign the mesh
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }
        meshFilter.mesh = mesh;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
        }
        // Assign a material (replace with your material)
        meshRenderer.material = new Material(Shader.Find("Standard")); 
    }
}