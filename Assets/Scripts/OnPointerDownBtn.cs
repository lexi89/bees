using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPointerDownBtn : MonoBehaviour, IPointerDownHandler
{
	public UnityEvent OnPointerDownEvents;

	public void OnPointerDown(PointerEventData eventData)
	{
		OnPointerDownEvents.Invoke();
	}
}
