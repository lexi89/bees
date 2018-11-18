using System;
using System.Collections.Generic;
using Bees;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerClickHandler
{
	
	public static Action<Selectable> OnClicked;
	public static Selectable CurrentSelectable;
	
	public int Height{ get{ return _modelHeight; } }
	public int Width{ get{ return _modelWidth; } }
	
	[SerializeField] UnityEvent OnSelectedEvents;
	[SerializeField] bool _registerToGridOnStart;
	[SerializeField] int _modelHeight = 1;
	[SerializeField] int _modelWidth = 1;
	[SerializeField] bool _drawBuildplaces;
	List<Vector3> _buildSpots;
	internal GameObject UI;

	void Start()
	{
		if (_registerToGridOnStart)
		{
			foreach (Vector3 spot in GetSpotsOccupied())
			{
				GridController.Build(spot);	
			}
		}
	}
	
	public static void OnNewClickableSelected(Selectable newMoveable = null)
	{
		if (Moveable.IsWaitingForConfirmation) return;
		if(CurrentSelectable != null) CurrentSelectable.OnDeselected();
		CurrentSelectable = newMoveable;
		if(CurrentSelectable != null)CurrentSelectable.OnSelected();
	}
	

	public virtual void OnSelected()
	{
		if (_buildSpots == null)
		{
			_buildSpots = GetSpotsOccupied();
		}
		OnSelectedEvents.Invoke();
	}
	
	internal List<Vector3> GetSpotsOccupied()
	{
		List<Vector3> positions = new List<Vector3>(_modelHeight * _modelWidth);
		int bottomRight = (_modelHeight - 1) / 2;
		float bottomRightX = transform.position.x - bottomRight * GridController.Increment;
		float bottomRightZ = transform.position.z - bottomRight * GridController.Increment;
		Vector3 bottomRightCoord = new Vector3(bottomRightX,transform.position.y, bottomRightZ);
		for (int i = 0; i < _modelHeight; i++)
		{
			for (int j = 0; j < _modelWidth; j++)
			{
				Vector3 coord = bottomRightCoord;
				coord.x += i * GridController.Increment;
				coord.z += j * GridController.Increment;
				positions.Add(coord);
			}
		}

		return positions;
	}

	public virtual void OnDeselected()
	{
		
	}
	
	public bool CanBePlaced()
	{
		return GridController.CanBuildInSpots(GetSpotsOccupied());
	}


	public void OnPointerClick(PointerEventData eventData)
	{
		OnNewClickableSelected(this);
	}
	
	void OnDrawGizmos()
	{
		if (!_drawBuildplaces) return;
		Gizmos.color = Color.magenta;
		int bottomRight = (_modelHeight - 1) / 2;
		float bottomRightX = transform.position.x - bottomRight * GridController.Increment;
		float bottomRightZ = transform.position.z - bottomRight * GridController.Increment;
		Vector3 bottomRightCoord = new Vector3(bottomRightX,transform.position.y, bottomRightZ);
		for (int i = 0; i < _modelHeight; i++)
		{
			for (int j = 0; j < _modelWidth; j++)
			{
				Vector3 coord = bottomRightCoord;
				coord.x += i * GridController.Increment;
				coord.z += j * GridController.Increment;
				Gizmos.DrawCube(coord, Vector3.one*0.4f);
			}
		}
	}
}
