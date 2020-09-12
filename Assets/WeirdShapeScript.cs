using UnityEngine;

public class WeirdShapeScript : MonoBehaviour // Somehow liked this shape
{
   private Mesh _mesh;
   private Vector3[] _vertices;
   private int[] _triangles;

   private void Start()
   {
      _mesh = new Mesh();   // You forgot it don't do it again
      GetComponent<MeshFilter>().mesh = _mesh;
      
      CreateShape();
      UpdateShape();
      MakeItColorFul();
      _mesh.RecalculateNormals();
      
   }

   void CreateShape()
   {
      _vertices = new[]
      {
         new Vector3(0, 0, 0),
         new Vector3(0,0,1),
         new Vector3(1, 0, 0), 
         new Vector3(3,0,3),
         new Vector3(0,1,0), 
      };
      
      _triangles = new[]
      {
         0,1,2,
         1,3,2,
         0,2,4,
         0,4,3,
         0,4,1,
         0,3,4
      };
   }

   void UpdateShape()
   {
      _mesh.vertices = _vertices;
      _mesh.triangles = _triangles;
   }

   void MakeItColorFul()
   {
      Color[] colors = new Color[_vertices.Length];

      for (int i = 0; i < _vertices.Length; i++)
         colors[i] = Color.Lerp(Color.red, Color.green, _vertices[i].y);
      _mesh.colors = colors;
   }
}
