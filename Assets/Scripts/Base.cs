using System;
using System.Collections.Generic;
using Bees;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

public class Base : Moveable
{
	public Transform CollectionPoint;
	[SerializeField] ListVar<HiveBuilding> _hiveBuildings;
	[SerializeField] HivesManager _hiveManager;
	[SerializeField] IntVar _honeyCount;
	BaseData _state;
	List<Collector> _collectors = new List<Collector>();
	
	public List<Hive> Hives{get{ return _hiveManager.Hives; }}
	int collectorCapacity{
		get{
			int capacity = 0;
			foreach (var collector in _collectors)
			{
				capacity += collector.Capacity;
			}
			return capacity;
		}
	}
	
	int hiveCount{get{return _hiveManager.Hives.Count;}}
	
	void Awake()
	{
//		Load();
//		_hiveManager.OnFirstHiveBuilt += SpawnCollector;
	}

	public void DepositHoney(int honeyAmount)
	{
		_honeyCount.Add(honeyAmount);
//		_moneyCalculator.DepositHoney(honeyAmount);
		// Do effect.
	}

	void OnHiveBuiltChecks()
	{
		if (hiveCount == 1)
		{
			// first hive built. spawn collector.
			SpawnCollector();
		}
	}

	void SpawnCollector()
	{
//		GameObject collectorGO =Instantiate(CollectorPrefab, transform);
//		collectorGO.transform.position = _baseModel.position;
//		Collector col = collectorGO.GetComponent<Collector>();
//		_collectors.Add(col);
//		col.Init(this);
	}

	void Save()
	{
		BaseData newSave = new BaseData();
		ES3.Save<BaseData>("Base",newSave);	
	}

	[Button("Reset")]
	void ResetBase()
	{
		ES3.DeleteFile("Base");
		Save();
	}

	void Load()
	{
		if (ES3.KeyExists("Base"))
		{
			_state = ES3.Load<BaseData>("Base");
//			foreach (var field in _fields)
//			{
//				FieldData foundSavedField = _state.Fields.Find(bp => bp.Pos == field.transform.position);
//				field.Init(foundSavedField);
//			}

//			if (_state.HivesState != null)
//			{
//				_hiveManager.LoadHiveStates(_state.HivesState);
//			}
//			for (int i = 0; i < _state.CollectorCount; i++)
//			{
//				SpawnCollector();
//			}
		}
	}
	
	void OnApplicationQuit(){Save();}
}

[Serializable]
public class BaseData
{
//	public List<FieldData> Fields = new List<FieldData>();
//	public List<HiveState> HivesState = new List<HiveState>();
//	public int CollectorCount;
}