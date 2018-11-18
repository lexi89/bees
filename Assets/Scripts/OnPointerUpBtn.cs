using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPointerUpBtn : MonoBehaviour, IPointerUpHandler {

	public UnityEvent OnPointerUpEvents;

	public void OnPointerUp(PointerEventData eventData)
	{
		
		OnPointerUpEvents.Invoke();
	}
}
