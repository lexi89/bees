using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game Settings")]
public class GameSettings : ScriptableSingleton<GameSettings>
{

    [SerializeField] bool _resetGameOnQuit;
    public Font HeaderFont;
    public float HeaderSize; 
    
    public bool IsShovelUnlocked{ get{ return _shovel.IsUnlocked; } }
    
    
    [SerializeField] UnlockableItem _shovel;

    public void ResetGame()
    {
        _shovel.ResetStatus();
        PlayerPrefs.DeleteAll();
        Debug.LogWarning("Game reset.");
    }

    void OnDisable()
    {
        if (_resetGameOnQuit)
        {
            ResetGame();
        }
    }
}
