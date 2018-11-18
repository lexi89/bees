using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;

public class Hover : MonoBehaviour
{
	[SerializeField] AnimationCurve _animCurve;
	[SerializeField] float yHoverAmount = 0.1f;
	[SerializeField] float durationOneWay = 1f;
	void OnEnable()
	{
		Vector3 startPos = transform.position;
		Tween.Position(transform, startPos + Vector3.up * yHoverAmount, durationOneWay, 0f, _animCurve, Tween.LoopType.PingPong);
	}
}
