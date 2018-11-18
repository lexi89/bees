using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "UnlockableItem/New")]
public class UnlockableItem : ScriptableObject
{
	public static Action<UnlockableItem> OnUnlock = delegate {  };
	public Sprite Icon;
	public bool StartUnlocked;
	public string Description;
	
	[ShowInInspector]
	public bool IsUnlocked{
		get{ return PlayerPrefs.GetInt(name + "_isUnlocked", 0) == 1; } 
		private set{PlayerPrefs.SetInt(name + "_isUnlocked", value ? 1: 0);}
	}

	public void Unlock()
	{
		IsUnlocked = true;
		OnUnlock(this);
	}

	[Button("Reset")]
	public void ResetStatus()
	{
		IsUnlocked = StartUnlocked;
	}
	
}
