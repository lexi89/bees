using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Generator")]
public class GeneratorData : ScriptableObject
{
	public static Action OnPurchaseMade;
	public string DisplayName{ get{ return name.Substring(2, name.Length - 2); } }
	public int BaseCost;
	public float BaseIncome;
	public float CostMultiplier;
	public float CostNext{ get{ return BaseCost * (float) Math.Pow(CostMultiplier, AmountOwned); } }
	public float IncomePerSecond{get{ return BaseIncome * AmountOwned; }}
	public int AmountOwned{
		get{ return PlayerPrefs.GetInt(name + "_owned", 0); }
		private set{PlayerPrefs.SetInt(name + "_owned", value);}
	}
	public bool IsUnlocked{
		get{ return PlayerPrefs.GetInt(name + "_unlocked", 0) == 1; }
		set{PlayerPrefs.SetInt(name + "_unlocked", value ? 1 : 0);}
	}

	public void BuyOne()
	{
		AmountOwned++;
		RaisePurchaseEvent();
	}

	void RaisePurchaseEvent()
	{
		if (OnPurchaseMade != null) OnPurchaseMade();
	}
}
