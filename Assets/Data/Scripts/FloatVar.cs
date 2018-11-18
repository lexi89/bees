using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "newFloat", menuName = "Variable/Float")]
public class FloatVar : ScriptableObject
{
    public Action OnChange;
    public bool Persist;
    public float StartingValue;
    float _runtimeValue;
    [SerializeField] CumulativeMultiplier _cMultiplier;
    [ShowInInspector][ReadOnly] public float Value{get{return BaseValue * (_cMultiplier != null ? _cMultiplier.Value : 1f);}}
    
    [ShowInInspector][ReadOnly] float BaseValue
    {
        get{return Persist ? PlayerPrefs.GetFloat(name, StartingValue) : _runtimeValue;}
        set{
            if (Persist){
            PlayerPrefs.SetFloat(name,value);
        } else {
            _runtimeValue = value;    
        }
            if (OnChange != null) OnChange();
        }
    }
    
    void OnEnable()
    {
        if (!Persist) BaseValue = StartingValue;
    }

    public void Add(float amountToAdd)
    {
        BaseValue += amountToAdd;
    }
    
    public void Subtract(float amountToSub)
    {
        BaseValue -= amountToSub;
    }

    public void SetNewValue(float newValue)
    {
        BaseValue = newValue;
    }
    
    [Button("Reset Base Value")]
    public void ResetValue()
    {
        BaseValue = StartingValue;
    }

    [Button("Add 100")]
    void Add100()
    {
        Add(100f);
    }
}
