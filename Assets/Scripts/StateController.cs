using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Sirenix.OdinInspector;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] OverrideGameState _overrideState;
    [SerializeField] HivesController _hivesController;
    GameState State;
    static string filePath{ get{ return string.Format("{0}/{1}", Application.persistentDataPath, "state"); } } 
    
    void Awake()
    {
        if (_overrideState != null)
        {
            State = _overrideState.State;
        }
        else
        {
            Load();    
        }
    }

    void Load()
    {
        if(File.Exists(filePath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            State = (GameState)bf.Deserialize(file);
            file.Close();
            print("found a save.");
        }
        else
        {
            State = new GameState();
            print("No save found. Made new");
        }
        LoadManagers(State);
    }

    void LoadManagers(GameState newState)
    {
        _hivesController.LoadState(newState.HiveStates);
    }

    void Save()
    {
        if (_overrideState != null) return; // don't save override states.
        
        GameState newSave = new GameState();
        List<HiveState> currentHivesState = _hivesController.GetHivesState();
        newSave.HiveStates = currentHivesState;
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (filePath);
        bf.Serialize(file, newSave);
        file.Close();
    }

    [Button("Clear save data")]
    void ClearSave()
    {
        File.Delete(filePath);
        print(File.Exists(filePath) ? "delete failed." : "save file deleted.");
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