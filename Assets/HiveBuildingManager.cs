using Sirenix.OdinInspector;
using UnityEngine;

public class HiveBuildingManager : MonoBehaviour
{
    [SerializeField] GameObject _container;
    [SerializeField] GameObject _hiveBuildBtnPrefab;
    [SerializeField] Transform _contentParent;
    [SerializeField] HivesList _hivesList;
    [SerializeField] Hive _currentSelectedHive;

    public void ShowOptionsForHive(Hive _targetHive)
    {
        _currentSelectedHive = _targetHive;
        _container.SetActive(true);
    }

    public void OnNewHiveBuildingSelected(HiveBuilding _newHivebuilding)
    {
        // TODO: set new hive in the place.
    }
    
    [Button("Rebuild")]
    void BuildUI()
    {
        for (int i = 0; i < _contentParent.childCount; i++)
        {
            DestroyImmediate(_contentParent.GetChild(i).gameObject);
        }
        for (int i = 0; i < _hivesList.List.Count; i++)
        {
            GameObject newBtnGO = Instantiate(_hiveBuildBtnPrefab, _contentParent);
            newBtnGO.GetComponent<HiveBuildingUI>().SetupUIForNewHive(_hivesList.List[i], this);
        }
    }
}
