using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GridController : MonoBehaviour
{
	public static bool ShowGrid;
	public static float Increment = 0.5f;
	static Dictionary<Vector3,bool> GridEntries = new Dictionary<Vector3, bool>(); // true means there's something there.

	public static void Build(Vector3 pos)
	{
		GridEntries[pos] = true;	
	}
	
	public static bool CanBuildInSpots(List<Vector3> spotsToCheck)
	{
		foreach (Vector3 spot in spotsToCheck)
		{
			if (GridEntries.ContainsKey(spot) == false || GridEntries[spot]) return false;
		}
		return true;
	}


	public static bool CanBuild(Vector3 spotToCheck)
	{
		if (GridEntries.ContainsKey(spotToCheck) == false || GridEntries[spotToCheck] == false) return true;
		return false;
	}
	
	#if UNITY_EDITOR
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			ToggleGrid();
		}
	}
#endif

	[Button("Toggle Debug Grid")]
	void ToggleGrid()
	{
		ShowGrid = !ShowGrid;
	}
}
