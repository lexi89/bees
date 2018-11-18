using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridPlace : MonoBehaviour,IPointerDownHandler {
	public void OnPointerDown(PointerEventData eventData)
	{
//		BuildGrid.Place(transform);
	}

	public void Select()
	{
		
	}

	void OnDrawGizmos()
	{
		if (GridController.ShowGrid)
		{
			Gizmos.color = GridController.CanBuild(transform.position) ? Color.green : Color.red;
			Gizmos.DrawCube(transform.position, 
				new Vector3(GridController.Increment * 0.9f, GridController.Increment* 0.9f, GridController.Increment* 0.9f)); 
		}
	}
}
