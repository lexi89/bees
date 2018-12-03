using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class Collector : MonoBehaviour
{
	public int Capacity{ get{ return Mathf.RoundToInt(_carryCapacity.Value); } }
	[SerializeField] FloatVar _carryCapacity;
	[ShowInInspector] int _holdingHoneyAmount;
	[SerializeField] Spline _spline;
	[SerializeField] float _speed;
	Animator _anim;
	Hive _hive;
	Base _base;
	Transform _currentTarget;
	bool isGoingToHive;

	void Awake()
	{
		_anim = GetComponent<Animator>();
	}

	bool canWalk = true;
	void Update()
	{
		if (Vector3.Distance(transform.position, _spline.followers[0].target.position) < 0.1f)
		{
			canWalk = false;
		}
		_spline.followers[0].percentage += _speed * Time.deltaTime;
	}
	
	// continue here. coroutine for picking up honey and continuing.

	public void Init()
	{
		GoToHive();
	}

	void GoToHive()
	{
		_hive = _base.Hives.Random();
		isGoingToHive = true;
		GoTo(_hive.transform);	
	}

	void GoTo(Transform newTarget)
	{
		_currentTarget = newTarget;
		_anim.SetBool("IsWalking", true);
	}

	void Collect()
	{
		_anim.SetBool("IsWalking", false);
//		_holdingHoneyAmount = _hive.TakeHoney(Capacity);
		isGoingToHive = false;
		GoTo(_base.CollectionPoint);
	}
	
	void Deposit()
	{
		_anim.SetBool("IsWalking", false);
		_base.DepositHoney(_holdingHoneyAmount);
		_holdingHoneyAmount = 0;
		GoToHive();
	}
}
