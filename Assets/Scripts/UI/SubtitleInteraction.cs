using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleInteraction : MonoBehaviour
{
    [SerializeField] private string _SubTitle = "Null";
    private SubtitleController _Controller;

    private void Awake()
    {
        _Controller = FindObjectOfType<SubtitleController>();
    }

    public void OnSubtitle()
    {
        _Controller.SetSubtitleText(_SubTitle);
    }
}
