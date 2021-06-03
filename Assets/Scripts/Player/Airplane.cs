using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Airplane : MonoBehaviour
{
    [SerializeField]PlayerInput input;

    new Rigidbody2D rigidbody;

    [SerializeField]float moveSpeed = 10f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() {
        input.onMove += Move;
        input.onStopMove += StopMove;
    }
    private void OnDisable() {
        input.onMove -= Move;
        input.onStopMove -= StopMove;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.gravityScale = 0f;

        input.EnableGameplayInput();
    }

    void Move(Vector2 MoveInput)
    {
        //Vector2 moveAmount = MoveInput * moveSpeed;

        rigidbody.velocity = MoveInput * moveSpeed;
    }
    void StopMove()
    {
        rigidbody.velocity = Vector2.zero;
    }
}
