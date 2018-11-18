using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance;
	public bool CanMoveBuildings{
		get{ return PlayerPrefs.GetInt("canMove", 0) == 1; }
		set{PlayerPrefs.SetInt("canMove", value ? 1 : 0);}
	}
	[SerializeField] GameObject FlowerBuildUI;
	[SerializeField] GameObject HiveBuildUI;
	[SerializeField] GameObject _baseUI;
	Selectable _currentClickedObj;
	GameObject _activeUI;
	Base currentBase;
	
	void Awake()
	{
		Instance = this;
		Selectable.OnClicked += OnObjClicked;
		UnlockableItem.OnUnlock += OnItemUnlocked;
	}

	void OnDisable()
	{
		Selectable.OnClicked -= OnObjClicked;
		UnlockableItem.OnUnlock -= OnItemUnlocked;
	}

	void OnItemUnlocked(UnlockableItem item)
	{
		print("item unlocked " + item.name);
	}

	void OnObjClicked(Selectable newClickedObj)
	{
		_currentClickedObj = newClickedObj;
	}
	public void ShowBaseUI(Base baseSelected)
	{
		currentBase = baseSelected;
		ShowUI(_baseUI.gameObject);
	}

	void ShowUI(GameObject newUI)
	{
		if(_activeUI != null) _activeUI.SetActive(false);
		_activeUI = newUI.gameObject;
		_activeUI.SetActive(true);
	}

	public void SetTargetUIActive(bool isActive)
	{
		_activeUI.SetActive(isActive);
	}

	public void OnAddBeesPressed()
	{
		
	}

}
