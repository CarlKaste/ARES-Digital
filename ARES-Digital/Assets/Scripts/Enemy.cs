using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject deathEffect;

    private bool agroTowardsPlayer = false;
    private Vector3 effectOffset = new Vector3(0, 1.5f, 0);

    public void SwordKill()
    {
        StartCoroutine(Killed());
    }

    public void BurnKill()
    {
        StartCoroutine(Burned());
    }

    IEnumerator Burned()
    {
        StopCoroutine(AgroCoroutine());
        agroTowardsPlayer = false;
        GetComponent<CapsuleCollider>().enabled = false;
        animator.SetTrigger("BurnDeath");
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
        GameObject effect = Instantiate(deathEffect, this.transform.position + effectOffset, this.transform.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(effect);
    }

    IEnumerator Killed()
    {
        StopCoroutine(AgroCoroutine());
        agroTowardsPlayer = false;
        GetComponent<CapsuleCollider>().enabled = false;
        animator.SetTrigger("SlashDeath");
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
        GameObject effect = Instantiate(deathEffect, this.transform.position + effectOffset, this.transform.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(effect);

    }

    IEnumerator AgroCoroutine()
    {
        transform.LookAt(player);
        animator.SetTrigger("Roar");
        yield return new WaitForSeconds(5f);
        animator.SetBool("Walk", true);
        agroTowardsPlayer = true;
    }

    public void AgroTowardsPlayer()
    {
        StartCoroutine(AgroCoroutine());
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
