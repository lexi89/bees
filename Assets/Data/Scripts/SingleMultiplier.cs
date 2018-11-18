using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Multiplier/Single Multiplier")]
public class SingleMultiplier : ScriptableObject
{
	[SerializeField] FloatVar _cash;
	public float MultiplierPerLevel;
	public List<int> CostsPerLevel = new List<int>();
	public int NextLevel;
	public string Description;
	
	[ShowInInspector][ReadOnly]public float Value{ get{ return 1+ PercentageDecimal;}}
	public string PercentageString{ get{ return string.Concat(PercentageDecimal*100, "%"); } }
	[ShowInInspector]
	public float UpgradeCost{get{return NextLevel >= CostsPerLevel.Count ? -1 : CostsPerLevel[NextLevel];}}
	[ShowInInspector] public float PercentageDecimal{ get{ return NextLevel * MultiplierPerLevel; } }
	[ShowInInspector] public bool IsMaxed{ get{ return NextLevel >= CostsPerLevel.Count; } }
	
	[Button("Buy upgrade")]
	public void BuyNextLevel()
	{
		if (IsMaxed)
		{
			Debug.LogWarning("trying to upgrade something that is maxed out",this);
			return;
		}

		if (_cash.Value < UpgradeCost)
		{
			Debug.LogWarning("trying to upgrade without enough cash");
			return;
		}
		
		NextLevel++;
	}

	[Button("Reset")]
	void ResetData()
	{
		NextLevel = 0;
	}
}
