using Sirenix.OdinInspector;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public HiveState State{ get{ return _state; } }
    public int CurrentLevelIndex{ get{ return _state.LevelIndex; } }
    public HiveBuilding CurrentHiveBuilding{ get; private set; }
    public bool HasSpaceForNewBee{get{ return CurrentLevelIndex >= 0 && _state.BeeCount + 1 <= CurrentHiveBuilding.BeeCapacity; }}
    [SerializeField] FloatVar _honeyCount;
    [SerializeField] int _startingLevelIndex;
    [SerializeField] HivesList _hivesList;
    [SerializeField] HoneyCalculator _honeyCalculator;
    [SerializeField] NewBeeCalculator _beeCalculator;
    [SerializeField] AnimationSequence _pulseSequence;
    [SerializeField] FloatVar _honeyValue;
    [SerializeField] FloatVar _cash;
    [SerializeField] bool _drawPoint;
    [SerializeField][ReadOnly] HiveState _state;
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

    public void OnNewHiveBuildingSelected(HiveBuilding _newHiveBuilding)
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
        _honeyCount.Add(honeyToAdd);
        AddMoney(honeyToAdd);
    }

    void AddMoney(float honeyAmount)
    {
        _cash.Add(honeyAmount * _honeyValue.Value);
    }

    void OnDrawGizmos()
    {
        if (!_drawPoint) return;
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
