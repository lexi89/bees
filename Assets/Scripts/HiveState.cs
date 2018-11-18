using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HiveState
{
    public int LevelIndex;
    public float BeeCount; // having this as a float makes it easier to calculate bee spawns per tick

    public HiveState(int startingLevelIndex)
    {
        LevelIndex = startingLevelIndex;
    }

    public HiveState()
    {
        LevelIndex = -1;
    }
}