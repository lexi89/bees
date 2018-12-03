using System.Collections;
using System.Collections.Generic;
using Bees;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Analytics;

public class BuildOptions : MonoBehaviour
{
	public static BuildOptions Instance;
	[SerializeField] Camera _cam;
	[SerializeField] Moveable _target;
	[SerializeField] RectTransform _uiTarget;
	[SerializeField] GameObject _container;
	bool isInBuildMode;

	void Awake()
	{
		Instance = this;
	}

	[Button("Test")]
	void SnapToTarget()
	{
		Vector2 Screenpos = _cam.WorldToScreenPoint(_target.transform.position);
		#if UNITY_EDITOR
		Rect screenRect = GameView.GetGameViewRect();
		#else
		Rect screenRect = Screen.safeArea;
		#endif
		Screenpos.y = Screenpos.y - screenRect.height/2;
		Screenpos.x = Screenpos.x  - screenRect.width/2;
		_uiTarget.GetComponent<RectTransform>().anchoredPosition = Screenpos;
	}
	
	void Update()
	{
		if (isInBuildMode)
		{
			SnapToTarget();
		}
	}

	public void OnBuildConfirm()
	{
		if (_target.CanBePlaced() == false) return;
		isInBuildMode = false;
		_container.SetActive(false);
		_target.OnMoveConfirmed();
	}

	public void OnBuildCancel()
	{
		isInBuildMode = false;
		_container.SetActive(false);
		_target.OnMoveCanceled();
	}

	public void ShowBuildOptionsForTarget(Moveable newTarget)
	{
		_target = newTarget;
		_container.SetActive(true);
		isInBuildMode = true;
	}
}
