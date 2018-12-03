using System.Collections;
using System.Collections.Generic;
using Bees;
using UnityEngine;

public class CanBuildQuad : MonoBehaviour
{
	[SerializeField] Color _canBuildColor;
	[SerializeField] Color _cannotBuildColor;
	[SerializeField] MeshRenderer _mesh;
	List<Vector3> _buildSpots;
	Moveable target;

	void Awake()
	{
		Moveable.OnMoveableSelected += delegate(Moveable newMoveable)
		{
			target = newMoveable;
			float newScale = newMoveable.Width * GridController.Increment;
			_mesh.transform.localScale = new Vector3(newScale, newScale, newScale);
		};
	}

	void Update()
	{
		_mesh.gameObject.SetActive(Moveable.IsWaitingForConfirmation);
		if (!Moveable.IsWaitingForConfirmation) return;
		Vector3 newPos = target.transform.position;
		newPos.y = 0.011f;
		transform.position = newPos;
		_mesh.material.color = target.CanBePlaced() ? _canBuildColor : _cannotBuildColor; 
	}
}
