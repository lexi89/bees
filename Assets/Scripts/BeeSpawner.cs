using System.Collections.Generic;
using System.Linq;
using Pixelplacement;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
	[SerializeField] GameObject _beePrefab;
	[SerializeField] Transform _spawnPos;
	[SerializeField] Transform _flyOutPoint;
	[SerializeField] HivesController _hivesController;
	List<Hive> _hives{ get{ return _hivesController.Hives; } }
	List<Hive> _availableHives{get{return _hives.Where(hive => hive.HasSpaceForNewBee).ToList();}}
	// TODO: optimise. Don't need to make a new list everytime.
	
	public void SpawnNewBee()
	{
		//  TODO: stop spawning if at capacity.
		if (_hives.Count == 0) return;
		GameObject newBeeGO = Instantiate(_beePrefab, _spawnPos.position,Quaternion.identity);
		Hive targetHive = _availableHives.Random();
		targetHive.TryAddBees(1);
		newBeeGO.GetComponent<Bee>().GoToHive(targetHive, _flyOutPoint);
	}

	void Update()
	{
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Space)) SpawnNewBee();
		#endif
	}

	public void OnAddBeePressed()
	{
		SpawnNewBee();
	}
}
