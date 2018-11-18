using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{

	[SerializeField] GameObject _upgradesBtn;

	public void ShowUIForBase()
	{
		_upgradesBtn.SetActive(true);
	}
}
