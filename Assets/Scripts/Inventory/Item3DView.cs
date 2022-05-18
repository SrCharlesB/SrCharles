using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item3DView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform _SpawnPoint;
    private GameObject _CurrentPrefab;
    [SerializeField] private float _SmoothTime = 3.5f;
    private bool _CanMove;
    private Vector3 _Rotate;
    private float x;
    private float y;

    public void OnPointerDown(PointerEventData eventData)
    {
        _CanMove = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _CanMove = false;
    }

    private void Update()
    {
        var component = _SpawnPoint.GetComponentInChildren<Item3D>();
        if(_CanMove && component != null)
        {
            //print("3DView.View");
            _CurrentPrefab = component.gameObject;
            y += Input.GetAxis("Mouse Y") * (Time.deltaTime * _SmoothTime * 100);
            x -= Input.GetAxis("Mouse X") * (Time.deltaTime * _SmoothTime * 100);
            _CurrentPrefab.transform.localRotation = Quaternion.Euler(new Vector3(y, x, 0f));
        }
    }
}
