using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, IPlayerMoveStates
{
    [Header("Player Controller")]
    [SerializeField] private LayerMask _GroundMask;
    [SerializeField] Transform _Check;
    [SerializeField] float _GroundDistance = 0.4f;
    [SerializeField] CharacterController _Controller;
    [SerializeField] PlayerInputs _PlayerInputs;
    [SerializeField] PlayerConfig _PlayerConfig;
    float Speed;
    bool isGrounded;
    Vector3 Move;
    Vector3 velocity;
    bool _Run;

    public bool Running()
    {
        bool value = _Run;
        return value;
    }

    public bool Walking()
    {
        bool value = Move.magnitude > 0;
        return value;
    }

    void Awake()
    {
        Speed = _PlayerConfig.WalkSpeed;
    }

    float IPlayerMoveStates.Move()
    {
        float value;
        switch (_Run)
        {
            case true: 
                value = Move.magnitude * 2f; break;
            case false: 
                value = Move.magnitude; break;
        }
        return value;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(_Check.position, _GroundDistance, _GroundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Move = transform.right * _PlayerInputs.Move().x + transform.forward * _PlayerInputs.Move().z;
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(_PlayerConfig.JumpForce * -2f * _PlayerConfig.GravityForce);
        }  

        //print($"move: {_PlayerInputs.Move()}");
        _Run = Input.GetKey(KeyCode.LeftShift) && _PlayerInputs.Move().z > 0;
        switch(_Run)
        {
            case true:
                Speed = _PlayerConfig.RunSpeed;
                //print("Running");
            break;
            case false:
                if(Speed != _PlayerConfig.WalkSpeed)
                {
                    Speed = _PlayerConfig.WalkSpeed;
                }
            break;
        }

        //print($"Speed: {Speed}");
        //print($"Move: {Move.magnitude}, Velocity: {velocity}");
        _Controller.Move(Move * (Speed * Time.deltaTime));

        velocity.y += _PlayerConfig.GravityForce * Time.deltaTime;

        _Controller.Move(velocity * Time.deltaTime);

        Vector3 Gravity = new Vector3(0f, _PlayerConfig.GravityForce, 0f);
        _Controller.Move(Gravity * Time.deltaTime);
    }
}
