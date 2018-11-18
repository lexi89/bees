using UnityEngine;
using UnityEngine.EventSystems;

public class item : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] UnlockableItem _item;

    void OnEnable()
    {
        DoItemChecks();
    }

    void DoItemChecks()
    {
        gameObject.SetActive(!_item.IsUnlocked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _item.Unlock();
        DoItemChecks();
    }
}
