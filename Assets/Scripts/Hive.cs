using System;
using System.Collections.Generic;
using Bees;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hive : MonoBehaviour
{
    public Action<Hive> OnHoneyAdded = delegate {  };
    public HiveState State{ get{ return _state; } }
    public int BeeCount{ get{ return Mathf.FloorToInt(_state.BeeCount); } }
    public int CurrentLevelIndex{ get{ return _state.LevelIndex; } }
    public HiveBuilding CurrentHiveBuilding{ get; private set; }
    public bool HasSpaceForNewBee{get{ return CurrentLevelIndex >= 0 && _state.BeeCount + 1 <= CurrentHiveBuilding.BeeCapacity; }}
    [ShowInInspector] float _honeyCount;
    [SerializeField] int _startingLevelIndex;
    [SerializeField] HivesList _hivesList;
    [SerializeField] HoneyCalculator _honeyCalculator;
    [SerializeField] NewBeeCalculator _beeCalculator;
    [SerializeField] AnimationSequence _pulseSequence;
    HiveState _state = new HiveState(1);
    GameObject _currentModel;
    int _currentLevel;    
    float lastPulseTime;
    float pulseDuration;

    public void LoadState(HiveState newState)
    {
        _state = newState;
        if (newState.LevelIndex < 0 && _startingLevelIndex >= 0)
        {
            newState.LevelIndex = _startingLevelIndex; // overriding the starting index here if set.
        }
        LoadHiveLevel(newState.LevelIndex);
    }

    void LoadHiveLevel(int newLevelIndex)
    {
        if (newLevelIndex >= 0)
        {
            if (_currentModel != null) DestroyImmediate(_currentModel);
            _state.LevelIndex = newLevelIndex;
            CurrentHiveBuilding = _hivesList.List[newLevelIndex];
            _currentModel = Instantiate(CurrentHiveBuilding.ModelPrefab, transform.position,Quaternion.identity);
            _currentModel.transform.SetParent(transform);
            _currentModel.transform.position = transform.position;
            _honeyCalculator.enabled = true;
            _beeCalculator.enabled = true;
        }
        else
        {
            _honeyCalculator.enabled = false;
            _beeCalculator.enabled = false;
        }
    }

    void OnNewHiveBuildingSelected(HiveBuilding _newHiveBuilding)
    {
        LoadHiveLevel(_hivesList.List.IndexOf(_newHiveBuilding));
    }

    public void TryAddBees(float beesToAdd)
    {
        if (HasSpaceForNewBee == false)
        {
            print("at capacity for " + name);
            return;
        }
        _state.BeeCount += beesToAdd; 
    }

    public void OnBeeAdded()
    {
        if (Time.time > lastPulseTime + pulseDuration)
        {
            _pulseSequence.DoSequence();
            lastPulseTime = Time.time;
        }
    }
    
    public void AddHoney(float honeyToAdd)
    {
        _honeyCount += honeyToAdd;
        OnHoneyAdded(this);
    }
}
