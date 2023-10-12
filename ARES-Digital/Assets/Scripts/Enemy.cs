using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDies();
    public static event EnemyDies enemyDies;
    
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject deathEffect;

    private Transform player;
    private bool agroTowardsPlayer = false;
    private Vector3 effectOffset = new Vector3(0, 1.5f, 0);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        AgroTowardsPlayer();
    }

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
        GetComponent<CapsuleCollider>().enabled = false;
        enemyDies();
        StopCoroutine(AgroCoroutine());
        agroTowardsPlayer = false;
        animator.SetTrigger("BurnDeath");
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
        GameObject effect = Instantiate(deathEffect, this.transform.position + effectOffset, this.transform.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(effect);
    }

    IEnumerator Killed()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        enemyDies();
        StopCoroutine(AgroCoroutine());
        agroTowardsPlayer = false;
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
