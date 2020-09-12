using UnityEngine;

public class MeshGeneratorScript : MonoBehaviour
{
    private Mesh mesh;

    private Vector3[] vertices;

    private int[] triangles;

    [SerializeField]
    private int xSize = 20;

    [SerializeField]
    private int zSize = 20;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateShape();
    }
    void CreateShape()
    {
        vertices = new Vector3[(xSize+1)*(zSize+1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x,0,z);
                i++;
            }
        }
    }

    void UpdateShape()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    
    private void OnDrawGizmos()
    {
        //if(vertices == null) return;
        Debug.Log("not 0null");
        foreach (var vertex in vertices)
        {
            Gizmos.DrawSphere(vertex,.1f);
        }
    }

}
