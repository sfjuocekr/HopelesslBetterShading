using UnityEngine;

[RequireComponent (typeof (Mesh))]
[RequireComponent (typeof (MeshCollider))]
[RequireComponent (typeof (MeshRenderer))]
[RequireComponent (typeof (Rigidbody))]

public class WaveGenerator : MonoBehaviour
{
	[SerializeField]
	private float _scale = 0.1f;

	[SerializeField]
	private float _speed = 1f;

	[SerializeField]
	private float _noiseStrength = 1f;

	[SerializeField]
	private float _noiseOffset = 1f;

	private Vector3[] _baseHeight;
	private MeshFilter _meshFilter;
	private Rigidbody _rigidbody;
	private MeshCollider _meshCollider;

	private void Awake ()
	{
		_meshFilter = GetComponent<MeshFilter> ();
		_baseHeight = _meshFilter.mesh.vertices;

		_rigidbody = GetComponent<Rigidbody> ();
		_rigidbody.useGravity = false;
		_rigidbody.isKinematic = true;

		_meshCollider = GetComponent<MeshCollider> ();
	}

	private void Update ()
	{
		Mesh _mesh = _meshFilter.mesh;

		Vector3[] vertices = new Vector3[_baseHeight.Length];
		for (int i=0;i<vertices.Length;i++)
		{
			Vector3 _vertex = _baseHeight[i];
					_vertex.y += Mathf.Sin(Time.time * _speed+ _baseHeight[i].x + _baseHeight[i].y + _baseHeight[i].z) * _scale;
					_vertex.y += Mathf.PerlinNoise(_baseHeight[i].x + _noiseOffset, _baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)    ) * _noiseStrength;
			vertices[i] = _vertex;
		}
		_mesh.vertices = vertices;
		_mesh.RecalculateNormals();
	}

	private void FixedUpdate ()
	{
		_meshCollider.sharedMesh = _meshFilter.mesh;
	}
}