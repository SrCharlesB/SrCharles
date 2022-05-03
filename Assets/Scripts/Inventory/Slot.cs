using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[Serializable] class SlotSounds
{
    [HideInInspector] public AudioSource Source;
    public AudioClip Enter;
    public AudioClip Exit;
    public AudioClip Click;
}

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SlotItem Item;
    private Image _ItemImage;
    [SerializeField] SlotSounds _Sounds;
    private InventoryController _Controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        _Sounds.Source.PlayOneShot(_Sounds.Click);
        OnViewItem();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _Sounds.Source.PlayOneShot(_Sounds.Enter);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _Sounds.Source.PlayOneShot(_Sounds.Exit);
    }

    private void Awake()
    {
        Item = GetComponentInChildren<SlotItem>();
        _ItemImage = Item.GetComponent<Image>();
        _Sounds.Source = GetComponentInParent<AudioSource>();
        _Controller = GetComponentInParent<InventoryController>();
    }

    private void LateUpdate()
    {
        _ItemImage.enabled = (Item.Amount != 0);
    }

    private void OnViewItem()
    {
        if(Item.Amount == 0) {return;}
        _Controller.OptionsController.gameObject.SetActive(true);
        _Controller.OptionsController.OnViewItem(Item);
    }
}