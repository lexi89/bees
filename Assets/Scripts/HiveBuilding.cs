using UnityEngine;

[CreateAssetMenu(menuName = "Building/Hive/New", fileName = "New hive")]
public class HiveBuilding : ScriptableObject
{
	public Sprite Icon;
	public int Cost;
	public GameObject ModelPrefab;
	public int HoneyPerTick{get{ return _honeyPerTick; }}
	public int BeeCapacity{ get{ return Mathf.RoundToInt(_baseBeeCapacity * _beeCapacityUpgrades.Value); }}
	[SerializeField] CumulativeMultiplier _beeCapacityUpgrades;
	[SerializeField] CumulativeMultiplier _honeyCapacityUpgrades;
	[SerializeField] int _baseBeeCapacity;
	[SerializeField] int _honeyPerTick;
	// TODO: optimisation cache values instead of fetching new ones every time.
}