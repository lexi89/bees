using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class Collector : MonoBehaviour
{
	public int Capacity{ get{ return Mathf.RoundToInt(_carryCapacity.Value); } }
	[SerializeField] FloatVar _carryCapacity;
	[ShowInInspector]int _holdingHoneyAmount;
	Animator _anim;
	Hive _hive;
	Base _base;
	Transform _currentTarget;
	NavMeshAgent _agent;
	bool isGoingToHive;

	void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_anim = GetComponent<Animator>();
	}

	public void Init(Base newBase)
	{
		_base = newBase;
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
//		print("going to " + newTarget.name);
		_currentTarget = newTarget;
		_agent.SetDestination(newTarget.position);
		_anim.SetBool("IsWalking", true);
		_agent.isStopped = false;
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

	void LateUpdate()
	{
		if (_agent.isStopped) return;
		if(Vector3.Distance(transform.position, _currentTarget.position) < 0.4f)
		{
			_agent.isStopped = true;
			if (isGoingToHive)
			{
				Collect();	
			}
			else
			{
				Deposit();
			}
		}
	}
}
