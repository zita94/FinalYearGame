using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = PlayerCharacter.BaseSpeed;
    public bool sprint = false;
    public bool crouch = false;
    public bool attack = false;
    public Rigidbody2D rb;
    public static Vector2 moveDirection;
    public Animator myAnim;
    public Slider staminaBar;
    public float energyUsed = 0;
    public float energyDrainSpeed = 0.0002f;
    public float characterBaseStamina;
    public bool staminaLeft = true;

    private void Start()
    {
        characterBaseStamina = PlayerCharacter.BaseStamina;
        staminaBar.maxValue = characterBaseStamina;
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        CheckCrouch();
        CheckSprint();
        Attack();
        staminaBar.value = energyUsed;
        if (energyUsed >= characterBaseStamina)
        {
            staminaLeft = false;
            moveSpeed = PlayerCharacter.BaseSpeed * 0.5f;
        }
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
        if (!staminaLeft) { energyDrainSpeed = 0; return; }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = PlayerCharacter.BaseSpeed * 1.5f;
            sprint = true;
            myAnim.speed = 1.2f;
            energyDrainSpeed = 0.002f;
}
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            sprint = false;
            moveSpeed = PlayerCharacter.BaseSpeed;
            myAnim.speed = 1;
            energyDrainSpeed = 0;
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
        if (staminaLeft)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myAnim.SetBool("attack", true);
                energyUsed += 0.5f;
            }
            else
            {
                myAnim.SetBool("attack", false);
            }
        }else
        {
            myAnim.SetBool("stamina", false);
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
            energyUsed += energyDrainSpeed;
        }
    }
}
