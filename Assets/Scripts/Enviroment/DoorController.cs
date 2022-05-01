using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] class Sounds
{
    public AudioSource Source;
    public AudioClip CloseAudio;
    public AudioClip OpenAudio;
}

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 _Direction = Vector3.up;
    [SerializeField] private float _Angle = 90f;
    [SerializeField] private float _SmoothTime = 10f;
    [SerializeField] private float _CloseMultiplier = 1.2f;
    [SerializeField] private bool _State;
    [SerializeField] private bool _Lock;
    [SerializeField] private Sounds _Sounds;
    private Vector3 _Rotation;
    private Vector3 _InitialRotation;
    private void Awake()
    {
        _InitialRotation = transform.localEulerAngles;
    }

    void Update()
    {
        switch(_State)
        {
            case true: 
                _Rotation = Vector3.Lerp(_Rotation, (_Direction * _Angle), (Time.deltaTime * _SmoothTime));
                break;
            case false:
                _Rotation = Vector3.Lerp(_Rotation, (_InitialRotation), (Time.deltaTime * (_SmoothTime * _CloseMultiplier)));
                break;
        }

        transform.localRotation = Quaternion.Euler(_Rotation);
    }

    public void OnOpenDoor()
    {
        if(_Lock){
            print($"door: '{transform.name}' isLocked");    
        return; 
        }
        _State = !_State;
        switch(_State)
        {
            case true: 
                _Sounds.Source.PlayOneShot(_Sounds.OpenAudio);
                break;
            case false:
                _Sounds.Source.PlayOneShot(_Sounds.CloseAudio);
                break;
        }
    }

    public void OnLockDoor()
    {
        if(_Lock)
        {
            print($"UnLock: '{transform.name}'");
        }
    }
}
