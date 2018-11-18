using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "newInt", menuName = "Variable/Int")]
public class IntVar : ScriptableObject
{
    public Action OnChange;
    public bool Persist;
    public int StartingValue;
    int _runtimeValue;
    
    [ShowInInspector]
    [ReadOnly]
    int _currentValue;
    
    public int Value
    {
        get{return Persist ? PlayerPrefs.GetInt(name, StartingValue) : _runtimeValue;}
        private set{
            if (Persist){
                PlayerPrefs.SetInt(name,value);
            }else{
                _runtimeValue = value;    
            }
            if (OnChange != null){
                OnChange();
            }
            _currentValue = Value;
        }
    }

    public void SetNewValue(int newValue)
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
        _currentValue = Value;
    }

    public void Add(int amountToAdd)
    {
        Value += amountToAdd;
    }
    
    public void Subtract(int amountToSub)
    {
        Value -= amountToSub;
    }
    
    [Button("Reset Value")]
    public void ResetValue()
    {
        Value = StartingValue;
    }

    [Button("Increment")]
    public void Increment()
    {
        Value++;
    }

    [Button("Decrement")]
    public void Decrement()
    {
        Value--;
    }
    
}
