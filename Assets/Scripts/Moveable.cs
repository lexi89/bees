using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bees
{
    public class Moveable : Selectable, IDragHandler, IEndDragHandler
    {
        public static Action<Moveable> OnMoveableSelected = delegate {  };
        public static Action<Moveable> OnMoveableDeselected = delegate {  };
        public static Action<Moveable> OnBuildConfirmed = delegate {  };
        public static Action<Moveable> OnBuildCanceled = delegate {  };
        internal Action OnDragged = delegate {  };
        public static bool IsMoving{ get; private set; }
        public static bool IsWaitingForConfirmation{ get; private set; }
        public static bool IsInBuildMode;
        public bool IsSelected{ get; private set; }
        [SerializeField] LayerMask _buildPlaceLayer;
        
        internal Camera _mainCam;
        bool _canBeMoved;
        
        void Awake()
        {
            _mainCam = Camera.main;
        }

        public override void OnSelected()
        {
            IsSelected = true;
            IsMoving = true;
            OnMoveableSelected(this);
            _canBeMoved = GameSettings.Instance.IsShovelUnlocked;
            base.OnSelected();
        }

        public void ShowBuildOptionUI()
        {
            IsInBuildMode = true;
            IsWaitingForConfirmation = true;
            BuildOptions.Instance.ShowBuildOptionsForTarget(this);
        }

        public override void OnDeselected()
        {
            Deselect();
            base.OnDeselected();
        }

        public void OnMoveConfirmed()
        {
            IsWaitingForConfirmation = false;
            OnBuildConfirmed(this);
            Deselect();
        }

        public void OnMoveCanceled()
        {
            IsWaitingForConfirmation = false;
            OnBuildCanceled(this);
            Deselect();
        }

        void Deselect()
        {
            OnMoveableDeselected(this);
            IsMoving = false;
            IsSelected = false;
            IsInBuildMode = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!IsSelected || !_canBeMoved) return;
            IsMoving = true;
            IsInBuildMode = true;
            RaycastHit hit;
            Physics.Raycast(_mainCam.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity,_buildPlaceLayer);
            if (hit.collider != null)
            {
                transform.position = hit.transform.position;
                OnDragged();
//                    BuildGrid.Build(hit.transform.position);			
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!IsSelected || !_canBeMoved) return;
            
            // some kind of buildplace painter?
            RaycastHit hit;
            Physics.Raycast(_mainCam.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity,_buildPlaceLayer);
            if (hit.collider != null)
            {
                transform.position = hit.transform.position;
            }
            IsMoving = false;
//            IsSelected = false;
            IsInBuildMode = false;
        }
        
        
        
    }
}