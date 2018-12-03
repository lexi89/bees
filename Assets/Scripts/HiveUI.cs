using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiveUI : MonoBehaviour
{
	[SerializeField] HivesController _hiveController;
	[SerializeField] Image _icon;
	[SerializeField] TextMeshProUGUI _name;
	[SerializeField] GameObject _noHiveStuff;
	[SerializeField] GameObject _hiveStuff;
	[SerializeField] HiveBuildingManager _buildingManager;
	[SerializeField] GameObject _hivesUIContainer;
	bool hasHiveBuilding{ get{ return _targetHive.CurrentLevelIndex >= 0; } } // -1 is no hivebuildng.
	Hive _targetHive;
	HiveBuilding _currentHiveBuilding;
	
	void OnEnable()
	{
		_targetHive = _hiveController.Hives[transform.GetSiblingIndex()];
		if(hasHiveBuilding) _currentHiveBuilding = _targetHive.CurrentHiveBuilding;
		UpdateUI();
	}

	void UpdateUI()
	{
		_noHiveStuff.SetActive(!hasHiveBuilding);
		_hiveStuff.SetActive(hasHiveBuilding);
		if (hasHiveBuilding)
		{
			_icon.sprite = _currentHiveBuilding.Icon;
			_name.text = _currentHiveBuilding.name;
		}
	}

	public void ShowBuildOptionsForHive()
	{
		_buildingManager.ShowOptionsForHive(_targetHive);
		_hivesUIContainer.SetActive(false);
	}
}