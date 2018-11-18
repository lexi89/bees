using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiveUI : MonoBehaviour
{
	[SerializeField] Hive _targetHive;
	[SerializeField] Image _icon;
	[SerializeField] TextMeshProUGUI _name;
	[SerializeField] GameObject _noHiveStuff;
	[SerializeField] GameObject _hiveStuff;

	void OnEnable()
	{
		UpdateUI();
	}

	void UpdateUI()
	{
		bool hasHive = _targetHive.CurrentLevelIndex >= 0; // -1 is no hive.
		_noHiveStuff.SetActive(!hasHive);
		_hiveStuff.SetActive(hasHive);
		
		if (hasHive)
		{
			_icon.sprite = _targetHive.CurrentHiveBuilding.Icon;
			_name.text = _targetHive.CurrentHiveBuilding.name;
		}
	}

	public void AddNewHivePressed()
	{
		// show hive options.
	}
}