using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] class Mechanic
{
    public string Name;
    public Behaviour Component;
}

public class PlayerMechanics : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] List<Mechanic> _Mechanics;
    
    public void OnEnabledMachanic(string name)
    {
        foreach(Mechanic mechanic in _Mechanics)
        {
            mechanic.Component.enabled = (mechanic.Name == name);
        }
    }
}
