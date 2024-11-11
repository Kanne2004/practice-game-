using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Move : MonoBehaviour
{
    public bool chamDat;
    public float speed = 5f;
    public float jump = 3;
    public float traiPhai;

    public Rigidbody2D rb;
    public Animator anim;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        DiChuyen();
        Jump();
        canAttack();
        Crouch();
        Cast();
        Block();
        Win();
        Die();
        Dizzy();
    }

    private void DiChuyen()
    {
        traiPhai = Input.GetAxis("Horizontal1");
        rb.velocity = new Vector2(traiPhai * speed, rb.velocity.y);

        if (traiPhai < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (traiPhai > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetBool("walk", traiPhai != 0);
    }
    private void Jump()
    {
        if (chamDat == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                chamDat = false;
                if (Input.GetKey(KeyCode.J))
                {
                    anim.SetTrigger("flykick");
                }
            }
            anim.SetBool("jump", !chamDat);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dat"))
        {
            chamDat = true;
        }
    }
    public bool canAttack()
    {
        return traiPhai == 0;
    }
    private void Crouch()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("crouch", true);
        }
        else anim.SetBool("crouch", false);
    }
    private void Die()
    {
        if (Input.GetKey(KeyCode.Keypad9))
        {
            anim.SetBool("die", true);
        }
        else anim.SetBool("die", false);
    }
    private void Win()
    {
        if (Input.GetKey(KeyCode.Keypad8))
        {
            anim.SetBool("win", true);
        }
        else anim.SetBool("win", false);
    }
    private void Dizzy()
    {
        if (Input.GetKey(KeyCode.Keypad7))
        {
            anim.SetBool("dizzy", true);
        }
        else anim.SetBool("dizzy", false);
    }
    private void Block()
    {
        if (Input.GetKey(KeyCode.Keypad3))
        {
            anim.SetBool("block", true);
        }
        else anim.SetBool("block", false);
    }
    private void Cast()
    {
        if (Input.GetKey(KeyCode.Keypad4))
        {
            anim.SetBool("cast", true);
        }
        else anim.SetBool("cast", false);
    }
}

