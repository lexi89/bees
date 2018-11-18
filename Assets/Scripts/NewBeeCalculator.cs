using UnityEngine;

[RequireComponent(typeof(Hive))]
public class NewBeeCalculator : MonoBehaviour
{
	[SerializeField] FloatVar _queenBeeHatchRate;
	[SerializeField] FloatVar _tickRate;
	Hive _hive;
	float _tickRate_Cached;
	float _lastTick;

	void Awake()
	{
		_hive = GetComponent<Hive>();
		_tickRate_Cached = _tickRate.Value;
		_lastTick = Time.time;
	}

	void LateUpdate()
	{
		if (Time.time > _lastTick + _tickRate_Cached)
		{
			_hive.TryAddBees(_queenBeeHatchRate.Value);
			_lastTick = Time.time;
		}
	}
}
