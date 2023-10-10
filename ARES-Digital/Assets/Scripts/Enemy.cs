using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    private bool agroTowardsPlayer = false;

    public void SwordKill()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        agroTowardsPlayer = false;
        animator.SetTrigger("SlashDeath");
    }

    public void BurnKill()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        agroTowardsPlayer = false;
        animator.SetTrigger("BurnDeath");
    }

    IEnumerator EnemyAgroCoroutine()
    {
        animator.SetTrigger("Roar");
        transform.LookAt(player);
        yield return new WaitForSeconds(5f);
        animator.SetBool("Walk", true);
        agroTowardsPlayer = true;
        yield return null;
    }

    public void AgroTowardsPlayer()
    {
        StartCoroutine("EnemyAgroCoroutine");
    }

    private void Update()
    {
        if (agroTowardsPlayer)
        {
            gameObject.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);
            this.transform.LookAt(player);
        }
    }
}
