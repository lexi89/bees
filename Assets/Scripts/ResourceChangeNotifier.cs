using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceChangeNotifier : MonoBehaviour
{
	// Needs to sit on a world space canvas.
//	[SerializeField] GameObject _prefab;
//	[SerializeField] FloatVar _resourceToWatch;
//	[SerializeField] bool _listenToLosses;
	float _oldAmount;
	
//	public void ShowNotice()

	public static void SpendCash(Transform target)
	{
		
	}
	
	void Awake()
	{
//		_resourceToWatch.OnChange += OnChange;
//		_oldAmount = _resourceToWatch.Value;
	}

	void OnChange()
	{
//		if (_resourceToWatch.Value < _oldAmount && !_listenToLosses) return; // if we're not listening to losses, bounce out.
//		float currentAmount = _resourceToWatch.Value;
//		float changeAmount = currentAmount - _oldAmount;
//		GameObject newGO = Instantiate(_prefab, transform);
//		newGO.GetComponent<TMP_Text>().text = ((int)changeAmount).ToString();
//		_oldAmount = currentAmount;
	}
}
