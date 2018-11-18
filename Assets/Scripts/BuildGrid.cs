	using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BuildGrid : MonoBehaviour
{
	[SerializeField] bool _drawDebugGrid;
	[SerializeField] int _width = 10;
	[SerializeField] int _height = 10;
	static Dictionary<Vector3,bool> GridEntries = new Dictionary<Vector3, bool>(); // true means there's something there.
	static string[,] _grid;
	
	[SerializeField] GameObject _gridPlacePrefab;

	void Awake()
	{
//		_grid = new bool[_width,_height];
//		_grid = new string[_width, _height];
//		GenerateGrid();
	}

	void Load()
	{
		// loops through everything in the grid and tell it to load.
	}

//	public static void Place(Transform obj)
//	{
//		Vector2 gridIndex = PosToGridIndex(obj.position);
//		_grid[(int)gridIndex.x, (int)gridIndex.y] = obj.name;
//	}
//
//	public static bool IsEmpty(Vector3 position)
//	{
//		Vector2 gridIndex = PosToGridIndex(position);
//		return _grid[(int)gridIndex.x, (int)gridIndex.y] == null;
//	}

	[Button("ClearGrid")]
	void ClearGrid()
	{
		if (transform.childCount == 0) return;
		for (int i = transform.childCount - 1; i >= 0; i--)
		{
			DestroyImmediate(transform.GetChild(i).gameObject);
		}
		GridEntries.Clear();
	}

	[Button("Test")]
	void GenerateGrid()
	{
		Stopwatch sw = new Stopwatch();
		sw.Start();
		ClearGrid();
		_grid = new string[_width, _height];
		for (float x = -_width/2, gridX = 0; x < _width/2; x+= GridController.Increment, gridX+=GridController.Increment)
		{
			for (float z = -_height/2, gridZ = 0; z < _height/2; z+= GridController.Increment, gridZ+= GridController.Increment)
			{
				GameObject newCube = Instantiate(_gridPlacePrefab, transform);
				Vector3 newSpawnPos = new Vector3(x, 0, z);
				newCube.transform.position = newSpawnPos;
				newCube.name = string.Concat(gridX,"-", gridZ);
				if(GridEntries.ContainsKey(newSpawnPos)) Debug.LogWarning("There's already a grid entry with that name!");
				GridEntries[newCube.transform.position] = false;
//				string entryName = string.Format("{0}{1}", gridX, gridZ);
			}
		}
		sw.Stop();
	}

//	public static bool CanBuildInSpots(List<Vector3> spotsToCheck)
//	{
//		foreach (Vector3 spot in spotsToCheck)
//		{
//			if (GridEntries.ContainsKey(spot) == false || GridEntries[spot]) return false;
//		}
//		return true;
//	}

//	public static void Build(Vector3 pos)
//	{
//		GridEntries[pos] = true;	
//	}

//	static Vector2 PosToGridIndex(Vector3 position)
//	{
//		return new Vector2(position.x + _width/2, position.z + _height/2);
//	}
//
//	static Vector3 GridIndexToPos(Vector2 gridIndex)
//	{
//		return new Vector3(gridIndex.x - _width/2, 0, gridIndex.y - _width/2);
//	}

	void OnDrawGizmos()
	{
		
		if (!_drawDebugGrid || _grid == null) return;

		foreach (Vector3 point in GridEntries.Keys)
		{
			Gizmos.color = GridEntries[point] ? Color.red : Color.green;
			if (GridEntries[point])
			{
				Gizmos.DrawCube(point, Vector3.one * 0.45f);
			}
		}
	}
}
