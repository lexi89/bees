using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenericButton : MonoBehaviour
{
	[SerializeField] GameObject _priceContainer;
	[SerializeField] TMP_Text _priceText;
	[SerializeField] TMP_Text _CTAText;
	[SerializeField] Image _icon;
	Action _callback;
	ButtonInfo _currentInfo;

	void Awake()
	{
		GetComponent<Button>().onClick.AddListener(OnButtonPressed);
	}

	public void Setup(ButtonInfo newInfo)
	{
		_currentInfo = newInfo;
		_callback = newInfo.Callback;
		bool hasPrice = newInfo.Price > 0;
		_priceContainer.SetActive(hasPrice);
		if (hasPrice) _priceText.text = newInfo.Price.ToString();
		_CTAText.text = newInfo.CTA;
		if(newInfo.Icon != null) _icon.sprite = newInfo.Icon;
	}

	void OnButtonPressed()
	{
		if(_currentInfo.Price > 0) print("Spend " + _currentInfo.Price);
		_callback();
		UIcontroller.instance.HideBottomUI();
	}
}


public struct ButtonInfo
{
	public Action Callback;
	public Sprite Icon;
	public string CTA;
	public int Price;
}
