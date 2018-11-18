using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building/Flowertype")]
public class FlowerType : ScriptableObject
{
    [Header("Flower Settings")]
    public float GrowthPerWater;
    public GameObject Prefab;
    // Some more flower stuff here. Rate of growth? Water required?  
}


