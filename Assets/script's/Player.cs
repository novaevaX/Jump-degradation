using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject platformStandart;
    private Rigidbody2D rigidbody;
    private Animator animation;

    private float horizontalSpeed = 3f;
    private float direction;
    private bool moveLeft;
    private bool moveRight;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
    }


    void Update()
    {
        MovementPlayerHorizontal();
    }

    private void FixedUpdate()
    {
        updateAnimation();
        rigidbody.velocity = new Vector2(direction * horizontalSpeed, rigidbody.velocity.y);
    }

    private void MovementPlayerHorizontal()
    {
        if (moveLeft)
        {
            direction = -1f;
        }
        else if (moveRight)
        {
            direction = 1f;
        }
        else
        {
            direction = 0;
        }
    }

    private void updateAnimation()
    {
        if (rigidbody.velocity.y <= .1f)
        {
            animation.SetBool("isUp", false);
        }
        else
        {
            animation.SetBool("isUp", true);
        }
    }

    public void MoveLeftButtonDown()
    {
        moveLeft = true;
    }

    public void MoveLeftButtonUp()
    {
        moveLeft = false;
    }

    public void MoveRightButtonDown()
    {
        moveRight = true;
    }

    public void MoveRightButtonUp()
    {
        moveRight = false;
    }
}
