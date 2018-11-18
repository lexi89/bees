using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HivesController : MonoBehaviour
{
	[SerializeField] List<Hive> _hives;
	[SerializeField] FloatVar _beeCount;

	void Start()
	{
		SyncBeeCount();
	}

	void SyncBeeCount()
	{
		int beeCount = 0;
		foreach (var hive in _hives)
		{
			beeCount += hive.BeeCount;
		}
		_beeCount.SetNewValue(beeCount);
	}
}
