using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    public SpriteRenderer CharacterSpriteRenderer;
    public float Speed = 6f;

    public Animator CharAnimator;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        CharAnimator = GetComponent<Animator>();
    }

    public void Move(Vector2 dir)
    {
        _rigidbody2d.velocity = dir * Speed;
        if (_rigidbody2d.velocity.x < 0) CharacterSpriteRenderer.flipX = true;
        else CharacterSpriteRenderer.flipX = false;
    }
}
