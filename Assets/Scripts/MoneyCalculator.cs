using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCalculator : MonoBehaviour
{

	[SerializeField] FloatVar _pricePerHoneyUnit;
	[SerializeField] FloatVar _wallet;
	[SerializeField] FloatVar _honeyCount;
	
	public void DepositHoney(int depositAmount)
	{
		_honeyCount.Subtract(depositAmount);
		_wallet.Add(depositAmount * _pricePerHoneyUnit.Value);
	}
}
