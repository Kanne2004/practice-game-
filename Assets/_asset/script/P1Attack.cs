using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Attack : MonoBehaviour
{
    public Transform gunTip;
    public GameObject bullet;
    public bool AniAttack = false;
    public float TimeDelay = 1f;
    public float lastTime;
    public bool IsAttack = true;
    public Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

        Attacking();
    }

    public void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsAttack)
        {
            AniAttack = true;
            GameObject gameObject = Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            if (transform.localScale == new Vector3(-1, 1, 1))
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            IsAttack = false;
            lastTime = Time.time;
        }

        if (Time.time > lastTime + 0.4f)
        {
            AniAttack = false;

        }
        Animator.SetBool("attack", AniAttack);
        //Animator.SetBool("CrouchAttack", AniAttack);
        //Animator.SetBool("JumpAttack", AniAttack);

        // tranh spam 
        if (Time.time > lastTime + TimeDelay)
        {
            IsAttack = true;

        }
    }
}