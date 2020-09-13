using System.Reflection;
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
        this.gameObject.AddComponent<MeshCollider>();
    }
    void CreateShape()
    {
        //float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0f);
        vertices = new Vector3[(xSize+1)*(zSize+1)];
        for (int i = 0, z = 0; z <= zSize; z++)    //(x+1) 
                                                    //(x+1)*2
                                                    //(x+1)*(z+1)       
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) ;
                vertices[i] = new Vector3(x,y,z); // (0,0,0) i = 0
                                                     // (1,0,0) i = 1
                                                     // (x,0,0) i = x+1
                i++;
            }
        }
        
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tri = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tri] = vert;
                triangles[tri + 1] = vert + xSize + 1;
                triangles[tri + 2] = vert + 1;
                triangles[tri + 3] = vert + 1;
                triangles[tri + 4] = vert + xSize + 1;
                triangles[tri + 5] = vert + xSize + 2;

                vert++;
                tri += 6;
            }
            vert++;
        }
    }
    
    void UpdateShape()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    
}
