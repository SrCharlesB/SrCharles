using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventorySetup : MonoBehaviour
{
    [SerializeField] private GameObject _Inventory;
    //[SerializeField] private MenuPause _Pause;
    [SerializeField] private PlayerSetup _Setup;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _Inventory.SetActive(!_Inventory.activeInHierarchy);
            switch (_Inventory.activeInHierarchy)
            {
                case true: 
                    _Setup.OnEnablePlayer(false);
                    LockMouse.Lock(CursorLockMode.None, true);
                break;
                case false: 
                    _Setup.OnEnablePlayer(true);
                    LockMouse.Lock(CursorLockMode.Locked, false);
                break;
            }
        }
    }
}
