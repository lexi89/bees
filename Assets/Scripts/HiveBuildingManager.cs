using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class HiveBuildingManager : MonoBehaviour
{
    [SerializeField] GameObject _hiveBuildBtnPrefab;
    [SerializeField] Transform _contentParent;
    [SerializeField] HivesList _hivesList;
    [SerializeField] Hive _currentSelectedHive;
    

    public void ShowOptionsForHive(Hive _targetHive)
    {
        if (_contentParent.childCount != _hivesList.List.Count)
        {
            Debug.LogError("Hive building list and UI don't match. Rebuild the UI in edit mode.");
            BuildUI();
        }
        _currentSelectedHive = _targetHive;
//        _container.SetActive(true);
    }

    public void OnNewHiveBuildingSelected(HiveBuilding _newHivebuilding)
    {
        _currentSelectedHive.OnNewHiveBuildingSelected(_newHivebuilding);
        GetComponent<State>().Exit();
    }
    
    [Button("Rebuild")]
    void BuildUI()
    {
        ClearUI();
        for (int i = 0; i < _hivesList.List.Count; i++)
        {
            GameObject newBtnGO = Instantiate(_hiveBuildBtnPrefab, _contentParent);
            newBtnGO.GetComponent<HiveBuildingUI>().SetupUIForNewHive(_hivesList.List[i], this);
        }
    }

    [Button("Clear")]
    void ClearUI()
    {
        for (int i = 0; i < _contentParent.childCount; i++)
        {
            DestroyImmediate(_contentParent.GetChild(i).gameObject);
        }
    }
}
