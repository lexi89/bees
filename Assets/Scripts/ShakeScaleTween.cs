using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Pixelplacement.TweenSystem;
using Sirenix.OdinInspector;
using UnityEngine;

public class ShakeScaleTween : MonoBehaviour
{
	[SerializeField] bool _playOnEnable;
	[SerializeField] Vector3 _scaleMultiplier = Vector3.one;
	[SerializeField] float _duration;
	[SerializeField] AnimationCurve _animCurve;
	Vector3 _startingScale;
	bool _isPlaying;

	void OnEnable()
	{
		if(_playOnEnable) DoScale();
	}

	[Button("Test")]
	public void DoScale()
	{
		if (_isPlaying)return;
		Vector3 startingScale = transform.localScale;
		Vector3 targetScale = new Vector3(startingScale.x * _scaleMultiplier.x,
			startingScale.y * _scaleMultiplier.y,
			startingScale.z * _scaleMultiplier.z);
		Tween.LocalScale(transform, startingScale, targetScale, _duration, 0f, _animCurve, Tween.LoopType.None,
			() => _isPlaying = true,
			() => _isPlaying = false);
	}
}
