using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
	public static ResourceController Instance;
	[SerializeField] FloatVar _cash;
	[SerializeField] GameObject _cashSpentPrefab;

	void Awake()
	{
		Instance = this;
	}

	public void SpendCash(float amount, Transform target = null)
	{
		if (target != null)
		{
			GameObject GO = Instantiate(_cashSpentPrefab, target.position,Quaternion.identity);
			GO.transform.forward = Camera.main.transform.forward;
			TextMeshProUGUI text = GO.GetComponentInChildren<TextMeshProUGUI>();
			if (text != null)text.text = string.Format("-{0}", amount);
		}
	}
}
