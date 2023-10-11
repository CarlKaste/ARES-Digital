using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private float maxHealth;

    private float currentHealth;
    private bool agroTowardsPlayer = false;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void SwordKill()
    {
        GetComponentInParent<CapsuleCollider>().enabled = false;
        agroTowardsPlayer = false;
        animator.SetTrigger("Die");
    }

    IEnumerator AgroCoroutine()
    {
        animator.SetTrigger("ActivateBoss");
        yield return new WaitForSeconds(18f);
        agroTowardsPlayer = true;
    }

    public void AgroTowardsPlayer()
    {
        StartCoroutine("AgroCoroutine");
    }

    IEnumerator HitCoroutine()
    {
        agroTowardsPlayer = false;
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(5.5f);
        agroTowardsPlayer = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            SwordKill();
            agroTowardsPlayer = false;
        }
        else
        {
            StartCoroutine(HitCoroutine());
        }
    }

    private void FixedUpdate()
    {
        if (agroTowardsPlayer)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
            this.transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }
    }
}
