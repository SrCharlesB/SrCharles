using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private SlotItem m_Item;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        m_Item = GetComponentInChildren<SlotItem>();
    }
}
