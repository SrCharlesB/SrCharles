using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemOptionsController : MonoBehaviour
{
    [SerializeField] private Button _ExitButton;
    [SerializeField] private TMP_Text _Name;
    [SerializeField] private TMP_Text _Description;

    private void Awake()
    {
        _ExitButton.onClick.AddListener(delegate{
            Exit();
        });
    }

    private void Exit()
    {
        gameObject.SetActive(false);
    }

    public void OnViewItem(SlotItem slotItem)
    {

    }
}
