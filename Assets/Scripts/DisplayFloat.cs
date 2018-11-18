using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFloat : MonoBehaviour {

	[SerializeField] FloatVar _numberToWatch;
	[SerializeField] bool _roundDown;
	TMP_Text _textComponent;

	void Awake()
	{
		_textComponent = GetComponent<TMP_Text>();
		_numberToWatch.OnChange += UpdateUI;
		UpdateUI();
	}

	void UpdateUI()
	{
		_textComponent.text = _roundDown ? Mathf.FloorToInt(_numberToWatch.Value).ToString() : _numberToWatch.Value.ToString();
	}
}
