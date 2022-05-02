using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private TMP_Text _Text;
    [SerializeField] private float _DelayTime = 0.7f;
    [SerializeField] private float _TimeToDestroy = 5f;
    public void SetSubtitleText(string text)
    {
        _Text.text = text;
        StartCoroutine(ITextSubtitle());
    }

    private IEnumerator ITextSubtitle()
    {
        int textL = _Text.text.Length;
        _Text.maxVisibleCharacters = 0;
        for(int i = 0; i <= textL; i++)
        {
            _Text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(_DelayTime);
        }

        yield return new WaitForSeconds(_TimeToDestroy);
        _Text.maxVisibleCharacters = 0;
        _Text.text = "null";
        print($"Text Destroyed on: '{transform.name}'");
    }
}
