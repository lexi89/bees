using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierUI : MonoBehaviour
{
	[SerializeField] FloatVar _cash;
	[SerializeField] SingleMultiplier _multiplierData;
	[SerializeField] TMP_Text _name;
	[SerializeField] TMP_Text _description;
	[SerializeField] TMP_Text _nextCost;
	[SerializeField] TMP_Text _multiplierTotal;
	[SerializeField] CanvasGroup _buyBtn;
	[SerializeField] Image _fill;

	void OnEnable()
	{
		UpdateUI();
		_cash.OnChange += UpdateBuyBtn;
	}

	void OnDisable()
	{
		_cash.OnChange -= UpdateBuyBtn;
	}

	[Button("Update")]
	void UpdateUI()
	{
		_name.text = _multiplierData.name;
		_description.text = _multiplierData.Description;
		_multiplierTotal.text = _multiplierData.PercentageString;
		_fill.fillAmount = _multiplierData.PercentageDecimal;
		UpdateBuyBtn();
	}

	void UpdateBuyBtn()
	{
		if (!_multiplierData.IsMaxed)
		{
			bool canAffordUpgrade = _cash.Value > _multiplierData.UpgradeCost;
			_buyBtn.alpha = canAffordUpgrade ? 1f : 0.2f;
			_buyBtn.interactable = canAffordUpgrade;	
			_nextCost.text = string.Concat("$", _multiplierData.UpgradeCost);
		}
		else
		{
			_buyBtn.interactable = false;
			_nextCost.text = "MAXED";
			_buyBtn.alpha = 1f;
		}
	}

	public void OnBuyPressed()
	{
		_multiplierData.BuyNextLevel();
		UpdateUI();
	}
}
