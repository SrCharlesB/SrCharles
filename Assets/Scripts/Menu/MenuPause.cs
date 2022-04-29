using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] GameObject _Menu;
    [SerializeField] PlayerSetup _Setup;
    bool _IsPaused;
    void Start()
    {
        LockMouse.Lock(CursorLockMode.Locked, false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    public void OnPause()
    {
        _IsPaused = !_IsPaused;
        _Menu.SetActive(_IsPaused);
        _Setup.OnEnablePlayer(!_IsPaused);
        switch (_IsPaused)
        {
            case true: LockMouse.Lock(CursorLockMode.None, true); break;
            case false: LockMouse.Lock(CursorLockMode.Locked, false); break;
        }
    }
}
