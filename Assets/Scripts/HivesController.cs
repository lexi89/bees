using System.Collections.Generic;
using Bees;
using UnityEngine;

public class HivesController : MonoBehaviour
{
	public List<Hive> Hives{ get{ return _hives; } }
	[SerializeField] List<Hive> _hives;	
	
	public void LoadState(List<HiveState> _newHiveStates)
	{
		if (_newHiveStates.Count == 0)	
		{
			// if there are no states, make blank new ones.
			for (int i = 0; i < _hives.Count; i++)
			{
				_newHiveStates.Add(new HiveState());
			}
		}
		for (int i = 0; i < _newHiveStates.Count; i++)
		{
			Hives[i].LoadState(_newHiveStates[i]);
		}
	}

	public void OnBuildNewHivePressed()
	{
		UIcontroller.instance.HideUI();
	}

	public List<HiveState> GetHivesState()
	{
		List<HiveState> newStates = new List<HiveState>();
		foreach (Hive hive in _hives)
		{
			newStates.Add(hive.State);
		}
		return newStates;
	}
}