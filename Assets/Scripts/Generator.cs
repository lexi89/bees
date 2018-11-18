using System;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
	public GeneratorData GeneratorData{ get{ return _generatorData; } }
	[SerializeField] FloatVar _money;
	[SerializeField] GeneratorData _generatorData;
	[SerializeField] Text _amountOwned;
	[SerializeField] Text _viewsPerSecond;
	[SerializeField] Text _nextCost;
	[SerializeField] CanvasGroup _generatorCanvasGroup;
	[SerializeField] CanvasGroup _buyBtnCanvasGroup;

	void Start()
	{
		_money.OnChange += DoMoneyChecks;
		UpdateUI();
	}
	
	void DoMoneyChecks()
	{
		SetBtnActive(_money.Value >= _generatorData.CostNext);
	}

	void SetUnlockAvailable(bool isAvailable)
	{
		_generatorCanvasGroup.alpha =  isAvailable ? 1f : 0.2f;
		_generatorCanvasGroup.interactable = isAvailable;
	}

	public void Buy() // called by a button in editor
	{
		if (_money.Value < _generatorData.CostNext) return;
		_money.Subtract(_generatorData.CostNext);
		_generatorData.BuyOne();
		UpdateUI();
	}

	void UpdateUI()
	{
		_amountOwned.text = string.Concat(_generatorData.DisplayName, " : ", _generatorData.AmountOwned);
		_viewsPerSecond.text = string.Concat("Views / sec : ", _generatorData.IncomePerSecond);
		_nextCost.text = string.Concat("$", Math.Round(_generatorData.CostNext,2) );
	}

	void SetBtnActive(bool isActive)
	{
		_buyBtnCanvasGroup.interactable = isActive;
		_buyBtnCanvasGroup.alpha = isActive ? 1f : 0.5f;
	}
}
