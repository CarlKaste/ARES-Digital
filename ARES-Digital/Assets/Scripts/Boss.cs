using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    [SerializeField] private float maxHealth;

    private PlaySteps playSteps;
    private float currentHealth;

    public bool agroTowardsPlayer = false;


    private void Start()
    {
        currentHealth = maxHealth;
        playSteps = GameObject.FindGameObjectWithTag("NarrativeStoryManager").GetComponent<PlaySteps>();
    }

    public void Die()
    {
        GetComponentInParent<CapsuleCollider>().enabled = false;
        agroTowardsPlayer = false;
        animator.SetTrigger("Die");
    }
    IEnumerator HitByFireCoroutine()
    {
        animator.SetTrigger("FireHit");

        yield return new WaitForSeconds(2f);

        agroTowardsPlayer = true;
    }

    IEnumerator AttackCoroutine()
    {
        agroTowardsPlayer = false;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(4f);

        agroTowardsPlayer = true;
    }

    IEnumerator AgroCoroutine()
    {
        animator.SetTrigger("ActivateBoss");

        yield return new WaitForSeconds(18f);

        agroTowardsPlayer = true;
    }

    public void AgroTowardsPlayer()
    {
        StartCoroutine(AgroCoroutine());
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
            agroTowardsPlayer = false;
            playSteps.PlayStepIndex(2);
        }
        else
        {
            StartCoroutine(HitByFireCoroutine());
        }
    }

    private void FixedUpdate()
    {
        if (agroTowardsPlayer)
        {
            this.transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            float distanceTowardsPlayer = Vector3.Distance(this.transform.position, player.transform.position);
            if(distanceTowardsPlayer < 5f)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }
}
