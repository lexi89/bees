using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayFloat : MonoBehaviour {
	[SerializeField] FloatVar _numberToWatch;
	[SerializeField] bool _roundDown;
	[SerializeField] bool _prettyPrint;
	TMP_Text _textComponent;

	void Awake()
	{
		_textComponent = GetComponent<TMP_Text>();
		_numberToWatch.OnChange += UpdateUI;
		UpdateUI();
	}

	void UpdateUI()
	{
		if (_prettyPrint)
		{
			_textComponent.text = Formatter.Currency(_numberToWatch.Value);
		}
		else
		{
			_textComponent.text = _roundDown ? Mathf.FloorToInt(_numberToWatch.Value).ToString() : _numberToWatch.Value.ToString();	
		}
	}
}

public static class Formatter
{
	public static string Currency(float currency)
	{
		if(currency < 1000)
		{
			return string.Format("{0:0.00}", currency);
		}

		if(currency >= 1000 && currency < 1000000)
		{
			return string.Format("{0:0.0}K", currency / 1000);
		}

		if(currency >= 1000000 && currency < 1000000000)
		{
			return string.Format("{0:0.0}M", currency / 1000000);
		}

		if (currency >= 1000000000 && currency < Mathf.Pow(10, 12))
		{
			return string.Format("{0:0.0}B", currency / 1000000000);
		}

		if (currency >= Mathf.Pow(10, 12) && currency < Mathf.Pow(10, 15))
		{
			return string.Format("{0:0.0}t", currency / Mathf.Pow(10, 12));
		}

		if (currency >= Mathf.Pow(10, 15) && currency < Mathf.Pow(10, 18))
		{
			return string.Format("{0:0.0}q", currency / Mathf.Pow(10, 15));
		}

		if (currency >= Mathf.Pow(10, 18) && currency < Mathf.Pow(10, 21))
		{
			return string.Format("{0:0.0}Q", currency / Mathf.Pow(10, 18));
		}

		return string.Format("{0:0.0}s", currency / Mathf.Pow(10, 21));
	}
}
