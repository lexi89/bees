using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Multiplier/Cumulative Multiplier")]
public class CumulativeMultiplier : ScriptableObject
{
	// holds all the multiplier data and calculates the total value.
	[SerializeField] List<SingleMultiplier> _multipliers = new List<SingleMultiplier>();
	[ShowInInspector]public float Value{
		get{
			if (_multipliers.Count == 0) return 1;
			// add the multipliers, multiply by the value.
			float cumulativeMultiplier = 0f;
			foreach (var multiplier in _multipliers)
			{
				cumulativeMultiplier += multiplier.Value;
			}
			return cumulativeMultiplier;
		}
	}
	// TODO: optimsiation. cache the value instead of calculating it every time.
}




