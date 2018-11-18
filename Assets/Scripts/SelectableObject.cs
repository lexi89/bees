using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectableObject : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] UnityEvent OnSelected;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnSelected.Invoke();
    }
}
