using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{

	[SerializeField] int _frameRate;
	void Start ()
	{

		Application.targetFrameRate = _frameRate;
	}
}
