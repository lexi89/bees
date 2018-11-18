using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Hive))]
public class HoneyCalculator : MonoBehaviour
{
	Hive _hive;
	[SerializeField] FloatVar _tickRate;
	
	float lastTick = 0f;
	
	void Awake()
	{
		_hive = GetComponent<Hive>();
	}

	void LateUpdate()
	{
		if (Time.time >= lastTick + _tickRate.Value)
		{
//			_hive.AddHoney(_hive.CurrentHiveBuilding.HoneyPerTick);
			lastTick = Time.time;
		}
	}
}
