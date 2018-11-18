using TMPro;
using UnityEngine;

public class DisplayInt : MonoBehaviour
{
	[SerializeField] IntVar _intToWatch;
	TMP_Text _textComponent;

	void Awake()
	{
		_textComponent = GetComponent<TMP_Text>();
		_intToWatch.OnChange += UpdateUI;
		UpdateUI();
	}

	void UpdateUI()
	{
		_textComponent.text = _intToWatch.Value.ToString();
	}
}
