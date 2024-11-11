using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class P2Dash : MonoBehaviour
{
    public KeyCode dashKey;
    public float DashDistance = 4f; // khoang cach luot
    public float DashSpeed = 5f; // toc do luot
    public float DashDelay = 1f;
    public float DashTime;
    public bool ReadyToDash = false;
    public bool isDashing = false;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        check();
        Dashing();
        checkStrike();
        Strike();
    }


    void check()
    {
        if (Input.GetKeyDown(dashKey) && ReadyToDash)
        {

            isDashing = true;
            anim.SetBool("dash", true);
        }
    }
    void checkStrike()
    {
        if (Input.GetMouseButton(1) && ReadyToDash)
        {

            isDashing = true;
            anim.SetBool("strike", true);
        }
    }

    void Dashing()
    {
        if (isDashing)
        {
            ReadyToDash = false;
            float DashStep = DashSpeed * Time.deltaTime;
            if (transform.localScale.x < 0)
            {
                transform.position += new Vector3(-DashStep, 0, 0);

            }
            else
                transform.position += new Vector3(DashStep, 0, 0);
            DashDistance -= Mathf.Abs(DashStep);
            if (DashDistance < 0)
            {
                isDashing = false;
                anim.SetBool("dash", false);
                DashDistance = 4f;
            }
            DashTime = Time.time;
        }

        if (Time.time > DashTime + DashDelay)
        {
            ReadyToDash = true;
        }
    }
    void Strike()
    {
        if (isDashing)
        {
            ReadyToDash = false;
            float DashStep = DashSpeed * Time.deltaTime;
            if (transform.localScale.x < 0)
            {
                transform.position += new Vector3(-DashStep, 0, 0);

            }
            else
                transform.position += new Vector3(DashStep, 0, 0);
            DashDistance -= Mathf.Abs(DashStep);
            if (DashDistance < 0)
            {
                isDashing = false;
                anim.SetBool("strike", false);
                DashDistance = 4f;
            }
            DashTime = Time.time;
        }

        if (Time.time > DashTime + DashDelay)
        {
            ReadyToDash = true;
        }
    }

}
