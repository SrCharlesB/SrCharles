using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private List<Slot> _Slots;
    public ItemOptionsController OptionsController;
    public SlotItem GetItem(int indexID)
    {
        SlotItem item = new SlotItem();
        foreach(Slot slot in _Slots)
        {
            if(slot.Item.IndexID == indexID)
            {
                item = slot.Item;
            }
        }
        return item;
    }

    public void AddItem(SlotItem slotitem)
    {
        SlotItem item = new SlotItem();
        #region SetItemInformation
            item.IndexID = slotitem.IndexID;
            item.NameID = slotitem.NameID;
            item.Amount = slotitem.Amount;
            item.Name = slotitem.Name;
        #endregion

        foreach(Slot slot in _Slots)
        {
            if(slot.Item.Amount == 0)
            {
                slot.Item = item;
            }
        }
    }
}
