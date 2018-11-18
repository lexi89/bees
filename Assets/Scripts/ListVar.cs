using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ListVar<T> : ScriptableObject where T: ScriptableObject
{
    public List<T> List;
    
    public T GetBuildingByDataName(string nameToFind)
    {   
        return List.Find(b => b.name == nameToFind);
    }
    

    public T GetNext(T current)
    {
        if (List.IndexOf(current) + 1 >= List.Count) return current;
        return List[List.IndexOf(current) + 1];
    }
}
