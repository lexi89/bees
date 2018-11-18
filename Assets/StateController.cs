using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] HivesManager _hivesManager;
    
    const string filename = "State";
    
    void Awake()
    {
        Load();
    }

    void Load()
    {
        GameState loadedState = ES3.FileExists(filename) ? ES3.Load<GameState>(filename) : new GameState();
        LoadManagers(loadedState);
    }

    void LoadManagers(GameState newState)
    {
        _hivesManager.LoadState(newState.HiveStates);
    }

    void Save()
    {
        GameState newSave = new GameState();
        List<HiveState> _currentHivesState = _hivesManager.GetHivesState();
        newSave.HiveStates = _currentHivesState;
        ES3.Save<BaseData>(filename,newSave);
    }

    void OnApplicationQuit()
    {
        Save();
    }
}

[Serializable]
public class GameState
{
    public List<HiveState> HiveStates = new List<HiveState>();
}
