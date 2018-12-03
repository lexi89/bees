using System.Collections;
using Bees;
using UnityEngine;

public class TouchCameraMovement : MonoBehaviour
{
	[SerializeField] float _cameraSpeed;
	public Transform TargetCamera;
	Vector3 _dragStartWorldPos;
	Vector3 _previousTouchPos;
	bool moveToTarget;
	bool _isMoving;
	#if UNITY_EDITOR
	Vector3 _previousMousePos;
	
	#endif

	
	void LateUpdate()
	{
		if (Moveable.IsMoving) return;
		#if !UNITY_EDITOR
		if (Input.touchCount > 0)
				{
					Touch touch = Input.touches[0];
					switch (touch.phase)
					{
						case TouchPhase.Began:					
							break;
						case TouchPhase.Moved:
							float deltaX = touch.deltaPosition.x;
							float deltaY = touch.deltaPosition.y;
							TargetCamera.position -= transform.right * deltaX * _cameraSpeed;
							TargetCamera.position -= transform.up * deltaY * _cameraSpeed;
							_isMoving = true;
							break;
						case TouchPhase.Ended:
								break;
						default:
							break;
					}
				}
	#elif UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
		{
			_previousMousePos = Input.mousePosition;
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 delta = Input.mousePosition - _previousMousePos;
			float deltaX = delta.x;
			float deltaY = delta.y;
			TargetCamera.position -= transform.right * deltaX * _cameraSpeed;
			TargetCamera.position -= transform.up * deltaY * _cameraSpeed;
			_isMoving = true;
			_previousMousePos = Input.mousePosition;
		}
		#endif
		

		
	}
}

public delegate void SimpleEvent();