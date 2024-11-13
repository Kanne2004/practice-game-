using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Now;
    public float Cooldown = 0.7f;
    private bool hit = false;
    public float speed = 5f;
    public BoxCollider2D boxCollider2D;
    public Animator MyAnimator;

    private void Awake()
    {
        MyAnimator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        Now = Time.time;
    }

    private void Update()
    {
        if (hit) return;
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider2D.enabled = false;
        MyAnimator.SetTrigger("Explosion");
        Destroy(gameObject, Cooldown);
    }

    private void Movement()
    {
        float movement = Time.deltaTime * speed;
        if (transform.localScale.x < 0)
        {
            transform.Translate(-movement, 0, 0);
        }
        else
            transform.Translate(movement, 0, 0);
        if (Time.time > Now + 2)
        {
            Destroy(gameObject);
        }

    }
}