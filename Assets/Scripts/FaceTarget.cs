using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{

	[SerializeField] Transform _target;

	[Button("Face")]
	void Face()
	{
		transform.LookAt(_target.position * -1);
	}
}
