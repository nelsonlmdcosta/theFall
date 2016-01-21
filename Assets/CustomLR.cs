using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CustomLR : MonoBehaviour 
{
	private Vector3[] points =  new Vector3[4];

	private Vector3[] positions = new Vector3[2];
    private int[] triangles = new int[6];
    private Mesh mesh = new Mesh();
    private void Start()
    {
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;

        

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshFilter>().mesh.vertices = points;
        GetComponent<MeshFilter>().mesh.triangles = triangles;


    }

	public void SetMaterial(Material material)
	{
		GetComponent<MeshRenderer>().material = material;
	}

    public void SetPosition(int i, Vector3 position)
	{
		positions[i] = position;

		RefreshMesh();
	}

    private void RefreshMesh()
    {
        Vector3 right = Vector3.Cross((positions[1] - positions[0]).normalized, Vector3.up);

        points[0] = positions[0] + right / 30;
        points[1] = positions[0] - right / 30;
        points[2] = positions[1] + right / 30;
        points[3] = positions[1] - right / 30;

        GetComponent<MeshFilter>().mesh.vertices = points;
    }
}
