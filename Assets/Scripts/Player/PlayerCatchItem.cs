using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatchItem : MonoBehaviour
{
    [SerializeField] private float _RayRange = 2f;
    [SerializeField] private Transform _Direction;
    [SerializeField] private InventoryController _Controller;
    [SerializeField] private GameObject _UIComplete; //for prototype

    private void Awake()
    {
        _UIComplete.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if(Physics.Raycast(_Direction.position, _Direction.forward, out hit, _RayRange))
            {
                if(hit.transform.TryGetComponent(out Item3D item3D))
                {
                    //print($"Catch: {item3D.name}");
                    _Controller.AddItem(
                        item3D.Name,
                        item3D.Description,
                        item3D.NameID,
                        item3D.Amount,
                        item3D.IndexID
                    );
                    Destroy(item3D.gameObject);
                }
            }   
        }
    }
}
