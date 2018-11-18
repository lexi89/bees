using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiveBuildingUI : MonoBehaviour
{
    [SerializeField] FloatVar _cash;
    [SerializeField] HiveBuildingManager _hiveBuildingManager;
    [SerializeField] HiveBuilding _hiveBuilding;
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI _hiveNameText;
    [SerializeField] TextMeshProUGUI _hiveCapacityText;
    [SerializeField] TextMeshProUGUI _hivePriceText;
    [SerializeField] CanvasGroup _buyBtnCG;
    [SerializeField] Button _buyBtn;
    
    bool _canAffordToBuy{
        get{
            if (_hiveBuilding == null)
            {
                Debug.LogWarning("checking if can afford an upgrade without a hivebuilding assigned");
                return false;
            }
            return _cash.Value >= _hiveBuilding.Cost;
        }
    }


    public void SetupUIForNewHive(HiveBuilding newHiveBuilding, HiveBuildingManager newManager)
    {
        _hiveBuilding = newHiveBuilding;
        _hiveBuildingManager = newManager;
        UpdateUI();
    }
    
    void OnEnable()
    {
        UpdateBuyBtnState();
        _buyBtn.onClick.AddListener(OnBuyPressed);
        _cash.OnChange += UpdateBuyBtnState;
    }

    void OnDisable()
    {
        _buyBtn.onClick.RemoveListener(OnBuyPressed);
        _cash.OnChange -= UpdateBuyBtnState;
    }

    public void OnBuyPressed()
    {
        if (_canAffordToBuy)
        {
            _hiveBuildingManager.OnNewHiveBuildingSelected(_hiveBuilding);    
        }
    }

    void UpdateUI()
    {
        _icon.sprite = _hiveBuilding.Icon;
        _hiveNameText.text = _hiveBuilding.name;
        _hiveCapacityText.text = _hiveBuilding.BeeCapacity.ToString();
        _hivePriceText.text = _hiveBuilding.Cost.ToString();
        UpdateBuyBtnState();
    }

    void UpdateBuyBtnState()
    {
        _buyBtnCG.interactable = _canAffordToBuy;
        _buyBtnCG.alpha = _canAffordToBuy ? 1f : 0.2f;
    }

}
