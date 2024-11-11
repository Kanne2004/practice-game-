using UnityEngine;

public class P2Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    private Animator anim;
    private P2Move p2Move;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        p2Move = GetComponent<P2Move>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) && cooldownTimer > attackCooldown && p2Move.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
}
