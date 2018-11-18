using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "newString", menuName = "Variable/String")]
public class StringVar : ScriptableObject {

	public Action OnChange;
	public bool Persist;
	public string StartingValue;
	string _runtimeValue;
    
	[ShowInInspector]
	[ReadOnly]
	string CurrentValue;
    
	public string Value
	{
		get{return Persist ? PlayerPrefs.GetString(name, StartingValue) : _runtimeValue;}
		private set{
			if (Persist){
				PlayerPrefs.SetString(name,value);
			}else{
				_runtimeValue = value;    
			}
			if (OnChange != null){
				OnChange();
			}
			CurrentValue = Value;
		}
	}

	public void SetNewValue(string newValue)
	{
		Value = newValue;
	}
    
	// Reset value if not persistent.
	void OnDisable()
	{
		if (!Persist) Value = StartingValue;
	}

	void OnEnable()
	{
		if (!Persist) Value = StartingValue;
		CurrentValue = Value;
	}
    
	[Button("Reset Value")]
	public void ResetValue()
	{
		Value = StartingValue;
	}
}
