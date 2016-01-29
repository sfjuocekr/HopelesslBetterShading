using UnityEngine;

[RequireComponent (typeof (SphereCollider))]
[RequireComponent (typeof (Rigidbody))]

public class CameraRigController : MonoBehaviour
{
	private SphereCollider _sphereCollider;
	private Rigidbody _rigidbody;
	private float _timePressed;

	private void Awake ()
	{
		_sphereCollider = GetComponent<SphereCollider> ();
		_rigidbody = GetComponent<Rigidbody> ();

		_rigidbody.isKinematic = false;
		_rigidbody.useGravity = false;
		_sphereCollider.radius = 1f;

		_timePressed = 0f;
	}

	private void Update ()
	{
		_timePressed += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.G))
			_rigidbody.useGravity = !_rigidbody.useGravity;

		if (Input.GetAxisRaw ("Horizontal") != 0f)
		{
			_timePressed = 0f;
			_rigidbody.drag = 0f;
			_rigidbody.AddForce (transform.right * Input.GetAxisRaw ("Horizontal") * Time.deltaTime * 100f);
		}
			
		if (Input.GetAxisRaw ("Vertical") != 0f)
		{
			_timePressed = 0f;
			_rigidbody.drag = 0f;
			_rigidbody.AddForce (transform.forward * Input.GetAxisRaw ("Vertical") * Time.deltaTime * 100f);
		}
			
		if ((_timePressed > 0.1f) && (_rigidbody.drag == 0))
			_rigidbody.drag = 2f;

		transform.Rotate (new Vector3 (Input.GetAxisRaw ("Mouse Y"), Input.GetAxisRaw ("Mouse X"), 0f), Space.Self);
			//Vector3 (Input.GetAxisRaw ("Mouse Y"), Input.GetAxisRaw ("Mouse X"), 0f));
	}
}
