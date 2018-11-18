using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public static class ExtensionMethods {
    
    static Random rng = new Random();

    public static void SetAlpha(this Image image, float newAlpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
    }
    
    public static void SetAlpha(this Text text, float newAlpha)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, newAlpha);
    }

    public static T Random<T>(this T[] array){
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static T Random<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    
    public static float Random(this Vector2 v2)
    {
        return UnityEngine.Random.Range(v2.x, v2.y);
    }
    
    public static Vector3 Middle(this Vector3 v3)
    {
        return new Vector3(Screen.width/2, Screen.height/2, 0f);
    }
    
    public static Vector3 Middle(this Screen screen)
    {
        return new Vector3(Screen.width/2, Screen.height/2, 0f);
    }

    public static T Last<T>(this List<T> targetList)
    {
        return targetList[targetList.Count - 1];
    }
    
    public static List<T> GetRandoms<T>(this List<T> targetList, int numRandoms)
    {
        targetList.Shuffle();
        List<T> newList = new List<T>();
        for (int i = 0; i < numRandoms; i++)
        {
            newList.Add(targetList[i]);
        }
        return newList;
    }
    
    public static void Shuffle<T>(this IList<T> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
   
}
