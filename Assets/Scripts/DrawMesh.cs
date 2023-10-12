using UnityEngine;


public class DrawMesh : MonoBehaviour
{
    [SerializeField] Transform debugVisual1;
    [SerializeField] Transform debugVisual2;

    private Mesh mesh;
    private Vector3 lastMousePosition;

    private void Awake()
    {

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] trinagles = new int[6];

            vertices[0] = new Vector3(-1, +1);
            vertices[1] = new Vector3(-1, -1);
            vertices[2] = new Vector3(+1, -1);
            vertices[3] = new Vector3(+1, +1);

            uv[0] = Vector2.zero;
            uv[1] = Vector2.zero;
            uv[2] = Vector2.zero;
            uv[3] = Vector2.zero;

            trinagles[0] = 0;
            trinagles[1] = 3;
            trinagles[2] = 1;
            trinagles[3] = 1;
            trinagles[4] = 3;
            trinagles[5] = 2;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = trinagles;
            mesh.MarkDynamic();

            GetComponent<MeshFilter>().mesh = mesh;

            lastMousePosition = Extensions.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
            Vector2[] uv = new Vector2[mesh.vertices.Length + 2];
            int[] triangles = new int[mesh.vertices.Length + 6];

            mesh.vertices.CopyTo(vertices, 0);
            mesh.uv.CopyTo(uv, 0);
            mesh.triangles.CopyTo(triangles, 0);

            int vIndex = vertices.Length - 4;
            int vIndex0 = vIndex;
            int vIndex1 = vIndex + 1;
            int vIndex2 = vIndex + 2;
            int vIndex3 = vIndex + 3;

            Vector3 mouseForwardVector = (Extensions.GetMouseWorldPosition() - lastMousePosition).normalized;
            Vector3 normal2D = new Vector3(0, 0, -1);
            float lineThickness = 1f;
            Vector3 newVertexUp = Extensions.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D) * lineThickness;
            Vector3 newVertexDown = Extensions.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D * -1f) * lineThickness;

            uv[vIndex2] = Vector2.zero;
            uv[vIndex3] = Vector2.zero;

            int tIndex = triangles.Length - 6;

            triangles[tIndex + 0] = vIndex0;
            triangles[tIndex + 1] = vIndex2;
            triangles[tIndex + 2] = vIndex1;

            triangles[tIndex + 3] = vIndex1;
            triangles[tIndex + 4] = vIndex1;
            triangles[tIndex + 3] = vIndex1;
        }

        transform.position = Extensions.GetMouseWorldPosition();
    }
}
