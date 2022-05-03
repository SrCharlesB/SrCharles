using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemOptionsController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ItemsPrefabs;
    [SerializeField] private Transform _SpawnPoint;
    [SerializeField] private Button _ExitButton;
    [SerializeField] private TMP_Text _Name;
    [SerializeField] private TMP_Text _Description;

    private void Awake()
    {
        _ExitButton.onClick.AddListener(delegate
        {
            Exit();
        });
    }

    private void Exit()
    {
        gameObject.SetActive(false);
    }

    public void OnViewItem(SlotItem slotItem)
    {
        foreach (GameObject item in _ItemsPrefabs)
        {
            if (item.TryGetComponent(out Item3D item3D))
            {
                if (item3D.NameID == slotItem.NameID)
                {
                    //print("ItemsOptions.Instance");
                    //DetroyCurrentItem
                    var currentPrefab = _SpawnPoint.GetComponentInChildren<Item3D>();
                    if(currentPrefab != null)
                    {   
                        Destroy(currentPrefab.gameObject);
                    }
                    //
                    var instItem = Instantiate(item, _SpawnPoint.position, _SpawnPoint.rotation);
                    instItem.transform.SetParent(_SpawnPoint);
                    _Name.text = slotItem.Name;
                    _Description.text = slotItem.Description;
                }
            }
        }
    }
}
