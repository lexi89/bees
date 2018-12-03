using System.Collections.Generic;
using Bees;
using UnityEngine;

public class BuildArrows : MonoBehaviour
{

    bool isMoveableSelected;
    Moveable target;
    [SerializeField] GameObject _arrowContainer;
    [SerializeField] Transform _upArrow;
    [SerializeField] Transform _downArrow;
    [SerializeField] Transform _leftArrow;
    [SerializeField] Transform _rightArrow;
    
    void Awake()
    {
        Moveable.OnMoveableSelected += OnMoveableSelected;
        Moveable.OnMoveableDeselected += OnMoveableDeselected;
    }

    void OnMoveableDeselected(Moveable newMoveable)
    {
        if(GameSettings.Instance.IsShovelUnlocked == false) return;
        isMoveableSelected = false;
        _arrowContainer.SetActive(false);
        target = null;
    }

    void OnMoveableSelected(Moveable newMoveable)
    {
        if(GameSettings.Instance.IsShovelUnlocked == false) return;
        target = newMoveable;
        isMoveableSelected = true;
        _arrowContainer.SetActive(true);
    }

    void Update()
    {
        if (!isMoveableSelected) return;
        // move the arrows to the slots either side of the obj.
        Vector3 centerPoint = target.transform.position;
        centerPoint.y = 0.02f;
        Vector3 leftPoint = centerPoint;
        float sideUnits = (target.Width - 1) / 2;
        leftPoint.x += sideUnits * GridController.Increment + GridController.Increment;
        
        Vector3 rightPoint = centerPoint;
        rightPoint.x -= sideUnits * GridController.Increment + GridController.Increment;
        
        Vector3 upPoint = centerPoint;
        upPoint.z -= sideUnits * GridController.Increment + GridController.Increment;
        
        Vector3 downPoint = centerPoint;
        downPoint.z += sideUnits * GridController.Increment + GridController.Increment;
        _upArrow.position = upPoint;
        _downArrow.position = downPoint;
        _leftArrow.position = leftPoint;
        _rightArrow.position = rightPoint;

    }
}
