using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class SlotItem : Item, IPointerDownHandler, IPointerUpHandler
{
    private SlotManager Manager;
    private bool _Drag;
    private Transform _OriginalSlot;

    public void OnPointerDown(PointerEventData eventData)
    {
        _Drag = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _Drag = false;
    }

    private void Awake()
    {
        Manager = GetComponentInParent<SlotManager>();
    }

    private void Update()
    {
        if (Manager._CanDrag && _Drag)
        {
            var OriginalSlot = GetComponentInParent<Slot>();
            if (OriginalSlot != null)
            {
                _OriginalSlot = OriginalSlot.transform;
            }
            transform.SetParent(Manager._Cursor);
        }

        if (!Manager._CanDrag && !_Drag && _OriginalSlot != null)
        {
            transform.SetParent(_OriginalSlot);
            transform.localPosition = Vector3.zero;
        }

        //print($"Drag: {_Drag}, CanDrag: {Manager._CanDrag}");
    }
}
