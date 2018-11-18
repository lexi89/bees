using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
	Camera _cam;
	void Awake()
	{
		_cam = GetComponent<Camera>();
//		Buildplace.OnSelected += FocusOn;
	}

	[SerializeField] LayerMask _cameraPlaneLayer;
	public void FocusOn(Transform target)
	{
		// take forward vector of camera
		Vector3 forward = transform.forward;
		// shoot a ray out from the object in the opposite direction.
		RaycastHit hit;
		Ray ray = new Ray(target.position, -forward);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, _cameraPlaneLayer))
		{
			Vector3 planeHitPos = hit.point;
			Tween.Position(_cam.transform, planeHitPos, 0.2f, 0f);
		}

	}
}
