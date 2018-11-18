using System.Collections;
using System.Collections.Generic;
using Bees;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowLabelOnClick : MonoBehaviour,IPointerDownHandler {
	public void OnPointerDown(PointerEventData eventData)
	{
		if(Moveable.IsWaitingForConfirmation) return;
		UIcontroller.instance.ShowBottomUI(Utils.CleanName(name), null);
	}
}
