using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [Header("Setup")]
    public Transform _Cursor;
    public bool _CanDrag{ get; private set; }
    void Start()
    {
        
    }

    void Update()
    {   
        _Cursor.localPosition = Input.mousePosition;
        _CanDrag = GetChildren() == 0;
        //print($"Children: {GetChildren()}");
    }

    private int GetChildren()
    {
        var items = _Cursor.GetComponentsInChildren<SlotItem>();
        return items.Length;
    }
}
