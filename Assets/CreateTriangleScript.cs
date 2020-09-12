using UnityEngine;

public class CreateTriangleScript : MonoBehaviour
{
        Mesh _mesh;
        Vector3[] _vertices;
        int[] _triangles;

        private void Start()
        {
                _mesh = new Mesh();
                GetComponent<MeshFilter>().mesh = _mesh;
                CreateShape();
                UpdateMesh();
        }

        void CreateShape()
        {
                _vertices = new[]
                {
                        new Vector3(0,0,0),
                        new Vector3(0,0,1),
                        new Vector3(1,0,0),
                };
                _triangles = new[]
                {
                        0,1,2
                };
        }

        private void UpdateMesh()
        {
               _mesh.Clear();
               _mesh.vertices = _vertices;
               _mesh.triangles = _triangles;

        }
}
