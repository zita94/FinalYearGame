using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = PlayerCharacter.BaseSpeed;
    public bool sprint = false;
    public bool crouch = false;
    public bool attack = false;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator myAnim;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        CheckCrouch();
        CheckSprint();
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void CheckSprint()
    {
        if (crouch) { return; }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = PlayerCharacter.BaseSpeed * 1.5f;
            sprint = true;
            myAnim.speed = 1.2f;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            sprint = false;
            moveSpeed = PlayerCharacter.BaseSpeed;
            myAnim.speed = 1;

        }
    }

    private void CheckCrouch()
    {
        if (sprint) { return; }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
            moveSpeed = PlayerCharacter.BaseSpeed - 1;
        }
        else if (!Input.GetKey(KeyCode.LeftControl))
        {
            crouch = false;
            moveSpeed = PlayerCharacter.BaseSpeed;
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetBool("attack",true);
        }
        else
        {
            myAnim.SetBool("attack", false);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        myAnim.SetFloat("moveX", rb.velocity.x);
        myAnim.SetFloat("moveY", rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    private void OnAnimatorMove()
    {

    }
}
