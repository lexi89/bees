using System.Collections.Generic;
using Bees;
using TMPro;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
	public static UIcontroller instance;
	GameObject _activeUI;
	[SerializeField] TMP_Text _title;
	[SerializeField] List<GenericButton> _buttons;
	[SerializeField] GameObject _genericBtnsContainer;
	[SerializeField] GameObject _buildUI;
	[SerializeField] GameObject _flowersUI;
	[SerializeField] GameObject _buildBtn;
	[SerializeField] GenericUIPopup _genericPopup;

	void Awake()
	{
		instance = this;
	}

	void OnEnable()
	{
		Selectable.OnClicked += OnClicked;
		UnlockableItem.OnUnlock += OnItemUnlocked;
	}

	void OnDisable()
	{
		Selectable.OnClicked -= OnClicked;
		UnlockableItem.OnUnlock -= OnItemUnlocked;
	}

	void OnClicked(Selectable newTarget)
	{
		if(_activeUI!= null) _activeUI.SetActive(false);
	}

	void OnItemUnlocked(UnlockableItem item)
	{
		_genericPopup.SetupAndShowUI(item.name, item.Description, item.Icon);
	}

	public void ShowBuildUI()
	{
		HideBottomUI();
		_buildBtn.SetActive(false);
		ShowUI(_buildUI);
	}

	void Update()
	{
		_buildBtn.SetActive(!Moveable.IsWaitingForConfirmation);
	}

	public void ShowBottomUI(string newTitle, List<ButtonInfo> newButtons)
	{
		_title.gameObject.SetActive(false);
		_genericBtnsContainer.SetActive(false);
		_title.text = newTitle;
		_title.gameObject.SetActive(true);
		
		if (newButtons == null) return;
		int buttonCount = newButtons.Count;
		for (int i = 0; i < _buttons.Count; i++)
		{
			_buttons[i].gameObject.SetActive(i < buttonCount);
			if (i < buttonCount)
			{
				_buttons[i].Setup(newButtons[i]);
			}
		}
		_genericBtnsContainer.SetActive(true);
	}

	public void HideBottomUI()
	{
		_title.gameObject.SetActive(false);
		_genericBtnsContainer.SetActive(false);
	}

	public void HideUI()
	{
		if (_activeUI != null)
		{
			_buildBtn.SetActive(false);
			_activeUI.SetActive(false);
			_activeUI = null;
		}
	}
	
	public void ShowUI(GameObject newUI)
	{
		if(_activeUI != null) _activeUI.SetActive(false);
		_activeUI = newUI;
		if(_activeUI != null) _activeUI.SetActive(true); // activeUI can still be null. some things don't have ui.
	}
}

