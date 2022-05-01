using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerController _Controller;
    [SerializeField] private Animator _HeadAnimator;
    void Start()
    {
        
    }

    void Update()
    {
        var moveStates = _Controller.GetComponent<IPlayerMoveStates>();
        _HeadAnimator.SetFloat("Move", moveStates.Move());
    }
}
