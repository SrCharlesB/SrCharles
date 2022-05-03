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

    public void AddItem(string name, string description, string nameID, int amount, int indexID)
    {
        foreach(Slot slot in _Slots)
        {
            if(slot.Item.Amount == 0)
            {
                slot.Item.Name = name;
                slot.Item.Description = description;
                slot.Item.Amount = amount;
                slot.Item.IndexID = indexID;
                slot.Item.NameID = nameID;
                print($"Item Added: {name}");
                return;
            }
        }
    }
}
