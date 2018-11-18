using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebugCommands : MonoBehaviour {

    [MenuItem("Tools/Reset Game")]
    static void ResetGame()
    {
        GameSettings.Instance.ResetGame();
    }
}
